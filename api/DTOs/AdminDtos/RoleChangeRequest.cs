namespace api.DTOs.AdminDtos
{


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class RoleChangeRequest
    {
         public required string UserId { get; set; }
         public required string NewRole { get; set; }
    }
}