using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.Models; // Ensure you have the correct namespace for PriceAdjustmentRequest
using api.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

            // Retrieve the user using the provided userId from the request
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            try
            {
                // Call the asynchronous method to adjust prices
                await _adminService.AdjustServicePricesAsync(request.Percentage, request.UserId);
                return Ok("Prices adjusted successfully.");
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
