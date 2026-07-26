

namespace api.DTOs.AccountDtos

{
	using System.ComponentModel.DataAnnotations;
    public class EditUserDetailsDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}