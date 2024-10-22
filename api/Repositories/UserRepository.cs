using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers;
using api.Data;
using api.DTOs.AccountDtos;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ITitleCaseService _titleCaseService;
        private readonly ApplicationDBContext _context;

        public UserRepository(
            UserManager<AppUser> userManager,
            ITitleCaseService titleCaseService,
            ApplicationDBContext context)
        {
            _userManager = userManager;
            _titleCaseService = titleCaseService;
            _context = context;
        }

        public Task<AppUser> DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }


        public async Task<AppUser> GetUserByIdAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<AppUser> UpdateUserDetailsAsync(string userId, EditUserDetailsDto editUserDetailsDto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UnauthorizedAccessException("User not found");
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


            if (!string.IsNullOrWhiteSpace(editUserDetailsDto.Email))
            {
                user.Email = editUserDetailsDto.Email.ToLower();
                user.UserName = editUserDetailsDto.Email.ToLower();
            }

            if (!string.IsNullOrWhiteSpace(editUserDetailsDto.PhoneNumber))
            {
                user.PhoneNumber = editUserDetailsDto.PhoneNumber;
            }

            var updateUserResult = await _userManager.UpdateAsync(user);
            if (!updateUserResult.Succeeded)
            {
                throw new Exception(string.Join(", ", updateUserResult.Errors.Select(e => e.Description)));
            }

            return user;
        }
    }
}