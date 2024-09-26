using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.UserDtos
{
    public class GetUserDto
    {
       public string Name { get; set; }
       public string Surname { get; set; }
       public string IdentityNumber { get; set; }
       public DateTime DateOfBirth { get; set; }
       public string Gender { get; set; }
       public string CitizenshipStatus { get; set; }
       public string UserName { get; set; }
       public string Email { get; set; }
       public string PhoneNumber { get; set; }
    }
}