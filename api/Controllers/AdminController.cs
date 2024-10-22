using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.Models; 
using api.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Ensuring  the user is logged in to access this controller, so i d can be extracted 
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(AdminService adminService, UserManager<AppUser> userManager)
        {
            _adminService = adminService;
            _userManager = userManager;
        }

        [HttpPost("adjust-prices")]
        public async Task<IActionResult> AdjustPrices([FromBody] PriceAdjustmentRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request.");
            }

            // Retrieve the logged-in user's email from the token
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            // Find the user by their email
            var currentUser = await _userManager.FindByEmailAsync(userEmail);

            if (currentUser == null)
            {
                return StatusCode(500, "Internal Server Error: Unable to find user.");
            }

            // **Verify if the user is a Superuser**
            var isSuperuser = await _userManager.IsInRoleAsync(currentUser, "SuperUser");

            if (!isSuperuser)
            {
                return Forbid("Only Superusers can adjust prices."); //look up error handling make this better 
            }

            try
            {
                // Call the asynchronous method to adjust prices using the current user's ID
                await _adminService.AdjustServicePricesAsync(request.Percentage, currentUser.Id);
                return Ok("Prices adjusted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

    
}