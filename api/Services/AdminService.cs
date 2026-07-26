using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
	public class AdminService
	{
		private readonly ApplicationDBContext _context;
		private readonly UserManager<AppUser> _userManager;
		   private readonly RoleManager<IdentityRole> _roleManager;

		public AdminService(ApplicationDBContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
			_roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
		}

		public async Task AdjustServicePricesAsync(double percentage, string userId)
		{
			{

				// Validate if the user has permission
				var user = await _userManager.FindByIdAsync(userId);
				if (user == null)
				{
					throw new ArgumentException("User not found.");
				}

				var roles = await _userManager.GetRolesAsync(user);
				if (!roles.Contains("SuperUser")) // Replace "SuperUser" with the actual role name you want to check
				{
					throw new UnauthorizedAccessException("Only superusers can adjust service prices.");
				}

				var servicePrices = await _context.ServicePrices.ToListAsync(); // Ensure this accesses the correct DbSet
				foreach (var servicePrice in servicePrices)
				{
					servicePrice.AdjustPrice(percentage); // Assuming this method exists in your ServicePrice class
				}

				await _context.SaveChangesAsync();
			}
		}

			public async Task ChangeUserRoleAsync ( String userId, string NewRole)
			{
				 // Validate if the user has permission
				var user = await _userManager.FindByIdAsync(userId);
				if (user == null)

				{
					throw new ArgumentException("User not found.");
				}

				// check if the new role exists in the systems
				if (! await _roleManager.RoleExistsAsync(NewRole))
				throw new ArgumentException("Invalid role specified");
			

			var currentRoles = await _userManager.GetRolesAsync(user);
			await _userManager.RemoveFromRolesAsync(user, currentRoles);

			//ADDING NEW ROLE
			var result = await _userManager.AddToRoleAsync(user, NewRole);
			if (!result.Succeeded)
			throw new InvalidOperationException("Failed to change the user's role");

		}
	}
}
