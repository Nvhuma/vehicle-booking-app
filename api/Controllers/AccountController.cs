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

        private readonly IPasswordHistoryService _passwordHistoryService;

        public AccountController(
            UserManager<AppUser> userManager,
            ITokenService tokenService,
            SignInManager<AppUser> signInManager,
            IEmailService emailService,
            IPasswordHistoryService passwordHistoryService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _emailService = emailService;
            _passwordHistoryService = passwordHistoryService;
        }




        // Your methods
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto model) { return null; }

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
