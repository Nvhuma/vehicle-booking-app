using System.Web;
using api.DTOs.AccountDtos;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Extensions;


namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IIdService _idService;
        private readonly ITitleCaseService _titleCaseService;
        private readonly IPasswordHistoryService _passwordHistoryService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            UserManager<AppUser> userManager,
            ITokenService tokenService,
            SignInManager<AppUser> signInManager,
            IEmailService emailService,
            IPasswordHistoryService passwordHistoryService,
            IIdService idService,
            ITitleCaseService titleCaseService,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _emailService = emailService;
            _passwordHistoryService = passwordHistoryService;
            _idService = idService;
            _titleCaseService = titleCaseService;
            _logger = logger;
        }

        // Your methods
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingUser = await _userManager.FindByEmailAsync(registerDto.Email.ToLower());
                if (existingUser != null)
                {
                    return BadRequest(new { errors = new[] { "Email already exists." } });
                }

                var idExtractions = await _idService.ExtractIdDetailsAsync(registerDto.IdentityNumber);

                var appUser = new AppUser
                {
                    Name = _titleCaseService.ToTitleCase(registerDto.Name).Trim(),
                    Surname = _titleCaseService.ToTitleCase(registerDto.Surname).Trim(),
                    DateOfBirth = idExtractions.DateOfBirth,
                    IdentityNumber = registerDto.IdentityNumber,
                    CreatedDate = DateTime.Now,
                    UserName = registerDto.UserName,
                    Email = registerDto.Email.ToLower(),
                    PhoneNumber = registerDto.PhoneNumber,
                    CitizenshipStatus = idExtractions.CitizenshipStatus,
                    Gender = idExtractions.Gender,
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    // Save the password history
                    var passwordHash = _userManager.PasswordHasher.HashPassword(appUser, registerDto.Password);
                    await _passwordHistoryService.AddPasswordAsync(appUser.Id, passwordHash);

                    var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                    var confirmationLink = Url.Action("ConfirmEmail",
                                                      "Account",
                                                      new
                                                      {
                                                          userId = appUser.Id,
                                                          token = emailToken
                                                      },
                                                      Request.Scheme);

                    var recipientEmail = registerDto.Email.ToLower();
                    var subject = "Confirm Your Email";
                    var link = confirmationLink;
                    var fullName = $"{_titleCaseService.ToTitleCase(registerDto.Name).Trim()} {_titleCaseService.ToTitleCase(registerDto.Surname).Trim()}";
                    Console.WriteLine(emailToken);

                    try
                    {
                        await _emailService.SendEmailAsync(recipientEmail, subject, fullName, link, "WelcomeEmail");
                    }
                    catch (Exception ex)
                    {
                        await _userManager.DeleteAsync(appUser); // Cleanup by deleting the created user
                        return StatusCode(500, $"An error occurred while sending the confirmation email. Please try again.");
                    }

                    try
                    {
                        var roleResult = await _userManager.AddToRoleAsync(appUser, "SuperUser");

                        if (roleResult.Succeeded)
                        {
                            return Ok(new { message = "User registered successfully. Please check your email to confirm your account." });
                        }
                        else
                        {
                            return StatusCode(500, new { errors = roleResult.Errors.Select(e => e.Description) });
                        }
                    }
                    catch (Exception ex)
                    {
                        // Correctly return a response with the proper IActionResult and correct exception reference
                        return StatusCode(500, new { message = "An internal server error occurred.", exception = ex.Message });
                    }

                }
                else
                {
                    return StatusCode(500, new { errors = createdUser.Errors.Select(e => e.Description) });
                }
            }
            catch (Exception e) // Catch any exceptions that occur during the process
            {

                return StatusCode(500, new { message = "An internal server error occurred. This", exception = e.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email.ToLower());

            if (user == null) return Unauthorized(new { message = "Invalid email or password." });

            if (!user.EmailConfirmed) return Unauthorized(new { message = "Email is not confirmed." });

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                await _userManager.ResetAccessFailedCountAsync(user);
                
                var roles = await _userManager.GetRolesAsync(user);

                return Ok(
                    new
                    {
                        userName = user.UserName,
                        email = user.Email,
                        fullName = $"{_titleCaseService.ToTitleCase(user.Name).Trim()} {_titleCaseService.ToTitleCase(user.Surname).Trim()}",
                        token = _tokenService.CreateToken(user),
                        roles = roles
                        
                    }
                );
            }
            else if (result.IsLockedOut)
            {
                var lockedUntil = await _userManager.GetLockoutEndDateAsync(user);
                var totalSeconds = Math.Ceiling((lockedUntil?.Subtract(DateTimeOffset.Now).TotalSeconds) ?? 0);
                return Unauthorized(new { message = $"Your account is currently locked out please try again in {totalSeconds} seconds" });
            }
            else
            {
                var accessFailedCount = await _userManager.GetAccessFailedCountAsync(user);
                var maxFailedAccessAttempts = _userManager.Options.Lockout.MaxFailedAccessAttempts;
                var attemptsLeft = maxFailedAccessAttempts - accessFailedCount;

                return Unauthorized(new { message = $"Invalid username or password. You have {attemptsLeft} attemps left" });
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout() { return null; }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userEmail = User.GetUserEmail();
                var user = await _userManager.FindByEmailAsync(userEmail);
                if (user == null)
                {
                    return BadRequest("Invalid user.");
                }

                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                // checking if the current ACTIVE!!!! passwords match 
                var passwordVerificationResult = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, changePasswordDto.NewPassword);
                if (passwordVerificationResult == PasswordVerificationResult.Success)
                {
                    return BadRequest(new { errors = new[] { "You cannot reuse your current password" } });
                }

                var reusedPeriod = TimeSpan.FromDays(180);

                //checking reused password history 

                if (await _passwordHistoryService.IsPasswordReusedAsync(user.Id, changePasswordDto.NewPassword, reusedPeriod))
                {
                    return BadRequest(new { errors = new[] { "You cannot reuse a previous password." } });
                }

                var result = await _userManager.ResetPasswordAsync(user, resetToken, changePasswordDto.NewPassword);

                await _userManager.ResetAccessFailedCountAsync(user);

                return Ok("Password has been changes successfully");

            }

            //possible pitfall hance the logging  
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred.");
                return StatusCode(500, "An error occurred while processing your request. Please try again later.");
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
                if (user == null)
                {
                    return BadRequest("User not found");
                }


                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var encodedToken = HttpUtility.UrlEncode(resetToken);
                if (resetToken == null)
                {
                    return StatusCode(500, "Reset link could not be generated, please try again.");
                }

                var resetLink = $"{Environment.GetEnvironmentVariable("FRONT_END_LINK")}/resetpassword?userId={user.Id}&token={encodedToken}";
                Console.WriteLine($"Front End Link: {resetLink}"); 
                

                var recipient = forgotPasswordDto.Email;
                var subject = "Reset Password Request";
                var link = resetLink;

                await _emailService.SendEmailAsync(recipient, subject, user.Name, link, "forgotPassword");

                return Ok("Password reset email sent successfully.Please check email");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during user registration.");
                return StatusCode(500, "An error occurred while processing your request. Please try again later.");
            }
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return Redirect(Environment.GetEnvironmentVariable("FRONT_END_LINK"));
            }
            else
            {
                // Handle failure
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid User");

            }
            try
            {
                //passing the model instead of the "ResetPasswordDto"
                var user = await _userManager.FindByIdAsync(resetPasswordDto.UserId);
                if (user == null)
                {
                    return BadRequest("Invalid user");
                }

                //check that the new password matches the current

                var passwordVerificationResult = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, resetPasswordDto.NewPassword);
                if (passwordVerificationResult == PasswordVerificationResult.Success)
                {
                    return BadRequest(new { errors = new[] { "You cannot use the same Password, Please enter a new Password" } });
                }

                var reusedPeriod = TimeSpan.FromDays(180);

                // checking the paasword has been used in the past by the same user 
                if (await _passwordHistoryService.IsPasswordReusedAsync(user.Id, resetPasswordDto.NewPassword, reusedPeriod))
                {
                    return BadRequest(new { errors = new[] { "You cannot reuse a previous password" } });

                }

                var result = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.NewPassword);
                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);
                    return BadRequest(new { Errors = errors });
                }
                // save the new password hash in the password history to keep records of the passwords
                var passwordHash = _userManager.PasswordHasher.HashPassword(user, resetPasswordDto.NewPassword);
                await _passwordHistoryService.AddPasswordAsync(user.Id, passwordHash);


                var recipient = user.Email;
                var subject = "Password Successfully Reset";
                var templateName = "ConfirmPassword";


                //reset link must be decoded first!!
                await _emailService.SendEmailAsync(recipient, subject, user.Name, "ConfirmPassword", templateName);



                await _userManager.ResetAccessFailedCountAsync(user);
                return Ok("Password reset successful, proceed to log in");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured while processing, try again later");
            }
        }

        [HttpPatch("Edit-user-details")]
        //Using Patch becouse certain feilds will remain the same 
        public async Task<IActionResult> EditUserDetails([FromBody] EditUserDetailsDto editUserDetailsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Getting the currently logged-in user
                var userEmail = User.GetUserEmail();
                var user = await _userManager.FindByEmailAsync(userEmail);
                if (user == null)
                {
                    return Unauthorized("User not found");
                }

                // Apply updates only to fields that are provided (non-null)
                if (!string.IsNullOrWhiteSpace(editUserDetailsDto.Name))
                {
                    user.Name = _titleCaseService.ToTitleCase(editUserDetailsDto.Name).Trim();
                }

                if (!string.IsNullOrWhiteSpace(editUserDetailsDto.Surname))
                {
                    user.Surname = _titleCaseService.ToTitleCase(editUserDetailsDto.Surname).Trim();
                }

                if (!string.IsNullOrWhiteSpace(editUserDetailsDto.UserName))
                {
                    user.UserName = editUserDetailsDto.UserName;
                }

                if (!string.IsNullOrWhiteSpace(editUserDetailsDto.Email))
                {
                    user.Email = editUserDetailsDto.Email.ToLower();
                }

                if (!string.IsNullOrWhiteSpace(editUserDetailsDto.PhoneNumber))
                {
                    user.PhoneNumber = editUserDetailsDto.PhoneNumber;
                }

                var updateUserResult = await _userManager.UpdateAsync(user);
                if (!updateUserResult.Succeeded)
                {
                    return BadRequest(new { errors = updateUserResult.Errors.Select(e => e.Description) });
                }

                return Ok("User details updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while editing user details.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}