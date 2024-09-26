using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.UserDtos;
using api.Models;

namespace api.Mappers.UserMappers
{
    public static class UserMapper
    {
        public static GetUserDto ToGetUserDto (this AppUser userDetails)
        {
            if (userDetails == null)
            {
                return null;
            }

            return new GetUserDto
            {
                Name = userDetails.Name,
                Surname = userDetails.Surname,
                UserName = userDetails.UserName,
                Email = userDetails.Email,
                PhoneNumber = userDetails.PhoneNumber,
                DateOfBirth = userDetails.DateOfBirth,
                IdentityNumber = userDetails.IdentityNumber,
                Gender = userDetails.Gender,
                CitizenshipStatus = userDetails.CitizenshipStatus,

            };
        }
    }
}