using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.AccountDtos;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser> GetAllUsersAsync();
        Task<AppUser> GetUserByIdAsync(string userId);
        Task<AppUser> UpdateUserDetailsAsync(string userId, EditUserDetailsDto editUserDetailsDto);
        Task<AppUser> DeleteUser(string userId);
        
    }
}