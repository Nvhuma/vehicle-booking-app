using System.ComponentModel.DataAnnotations;

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

        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
         public string ConfirmPassword { get; set; }

        
    }
}