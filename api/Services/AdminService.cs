using System;
using System.Collections.Generic;
using System.Linq;
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

		public AdminService(ApplicationDBContext context, UserManager<AppUser> userManager)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
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
	}
}
