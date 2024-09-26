using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.AccountDtos;
using api.Interfaces;
using api.Models;

namespace api.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context){
            _context = context;
        }

        public Task<AppUser> DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetAllUsers()
        {
            throw new NotImplementedException();
        }


        public async Task<AppUser> GetUserById(string userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return null;
            }
            
            return user;
        }


        public Task<AppUser> UpdateUserDetails(string userId, EditUserDetailsDto editUserDetailsDto)
        {
            throw new NotImplementedException();
        }
    }
}