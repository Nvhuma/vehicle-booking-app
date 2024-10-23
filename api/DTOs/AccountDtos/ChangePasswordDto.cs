using System.ComponentModel.DataAnnotations;

namespace api.DTOs.AccountDtos 
{ 
	//changing when you are online
    public class ChangePasswordDto
    {
        [Required]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        public string ConfirmNewPassword { get; set; }
    }
}