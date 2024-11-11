namespace api.DTOs.AccountDtos
{

	using System.ComponentModel.DataAnnotations;


	public class RegisterDto
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Surname { get; set; }

		//[Required]
		//public string UserName { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string PhoneNumber { get; set; }

		[Required]
		public string Password { get; set; }

		[Compare("Password", ErrorMessage = "Passwords do not match.")]
		public string ConfirmPassword { get; set; }

		[Required]
		public string IdentityNumber { get; set; }
	}
}