using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.AccountDtos
{
    public class ResetPasswordDto
    {
        [Required]
        public string UserId {get; set ;}

        [Required]
        public string Token {get; set; }

        [Required(ErrorMessage ="The Password feild is required")]
        public string NewPassword {get; set;}

        [Required(ErrorMessage ="The password feild is reqiured")] 
         public string ConfirmPassword { get; set; }

        
    }
}