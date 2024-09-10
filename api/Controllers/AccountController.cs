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
        public IActionResult Login([FromBody] LoginDto model)  { return null; }

        [HttpPost("logout")]
        public IActionResult Logout()  { return null; }

        [HttpPost("change-password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordDto model) { return Ok(); }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword([FromBody] ForgotPasswordDto model) { return Ok(); }

        [HttpPost("reset-password")]
        public IActionResult ResetPassword([FromBody] ResetPasswordDto model) { return Ok(); }

        [HttpGet("confirm-email")]
        public IActionResult ConfirmEmail([FromQuery] string token) { return Ok(); }
    }
}
