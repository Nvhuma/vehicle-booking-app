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
        Task<AppUser> GetAllUsers();
        Task<AppUser> GetUserById(string userId);
        Task<AppUser> UpdateUserDetails(string userId, EditUserDetailsDto editUserDetailsDto);
        Task<AppUser> DeleteUser(string userId);
        
    }
}