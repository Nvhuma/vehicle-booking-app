using System.ComponentModel.DataAnnotations;

namespace api.DTOs.AccountDtos
{
    public class EditUserDetailsDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Surname { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}