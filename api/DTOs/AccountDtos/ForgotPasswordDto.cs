using System.ComponentModel.DataAnnotations;

namespace api.DTOs.AccountDtos
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]

        public string Email { get; set;}
    }
}