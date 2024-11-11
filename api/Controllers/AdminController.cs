namespace api.Controllers

{

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


	[ApiController]
	[Route("api/[controller]")]
	[Authorize] // Ensuring  the user is logged in to access this controller, so i d can be extracted 
	public class AdminController : ControllerBase
	{
		private readonly AdminService _adminService;
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AdminController(AdminService adminService, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_adminService = adminService;
			_userManager = userManager;
			_roleManager = roleManager;
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

		[HttpPost("change-role")]
		public async Task<IActionResult> ChangeUserRole([FromBody] DTOs.AdminDtos.RoleChangeRequest request)
		{
			if (request == null)
				return BadRequest("Invalid request.");

			// Retrieve the logged-in user's ID and verify their role
			var currentUserEmail = User.FindFirstValue(ClaimTypes.Email);
			var currentUser = await _userManager.FindByEmailAsync(currentUserEmail);

			if (currentUser == null)
				return StatusCode(500, "Internal Server Error: Unable to find user.");

			// Ensure only SuperUsers or Admins can access this endpoint
			var isAdmin = await _userManager.IsInRoleAsync(currentUser, "Admin");
			var isSuperuser = await _userManager.IsInRoleAsync(currentUser, "SuperUser");

			if (!isAdmin && !isSuperuser)
				return Forbid("Only SuperUsers or Admins can change user roles.");

			try
			{
				await _adminService.ChangeUserRoleAsync(request.UserId, request.NewRole);
				return Ok("User role changed successfully.");
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (InvalidOperationException ex)
			{
				return StatusCode(500, ex.Message);
			}
		}

		//get api/admin/roles
		[HttpGet("Roles")]
		public async Task<IActionResult> GetRolesAsync()
		{
			// Retrieve the logged-in user's ID and verify their role
			var currentUserEmail = User.FindFirstValue(ClaimTypes.Email);
			var currentUser = await _userManager.FindByEmailAsync(currentUserEmail);

			var roles = _roleManager.Roles.Select(role => new
			{
				role.Id,
				role.Name

			}).ToList();

			return Ok(roles);
		}


	}
}
