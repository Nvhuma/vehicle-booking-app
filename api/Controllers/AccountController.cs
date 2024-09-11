using api.DTOs.AccountDtos;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


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

        public AccountController(
            UserManager<AppUser> userManager,
            ITokenService tokenService,
            SignInManager<AppUser> signInManager,
            IEmailService emailService,
            IPasswordHistoryService passwordHistoryService,
            IIdService idService,
            ITitleCaseService titleCaseService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _emailService = emailService;
            _passwordHistoryService = passwordHistoryService;
            _idService = idService;
            _titleCaseService = titleCaseService;
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
                    Name =  _titleCaseService.ToTitleCase(registerDto.Name).Trim(),
                    Surname = _titleCaseService.ToTitleCase(registerDto.Surname).Trim(),
                    DateOfBirth = idExtractions.DateOfBirth,
                    IdentityNumber = registerDto.IdentityNumber,
                    CreatedDate =  DateTime.Now,
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
        public IActionResult Login([FromBody] LoginDto model) { return null; }

        [HttpPost("logout")]
        public IActionResult Logout() { return null; }

        [HttpPost("change-password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordDto model) { return Ok(); }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword([FromBody] ForgotPasswordDto model) { return Ok(); }


        [HttpGet("confirm-email")]
        public IActionResult ConfirmEmail([FromQuery] string token) { return Ok(); }


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

                await _userManager.ResetAccessFailedCountAsync(user);
                return Ok("Password reset successful, proceed to log in");

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured while processing, try again later");
            }
        }
    }
}
