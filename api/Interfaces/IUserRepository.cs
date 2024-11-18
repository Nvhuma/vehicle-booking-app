

namespace api.Interfaces
{
	using api.DTOs.AccountDtos;
	using api.Models;
	public interface IUserRepository
	{
		Task<AppUser> GetAllUsersAsync();
		Task<AppUser> GetUserByIdAsync(string userId);
		Task<AppUser> UpdateUserDetailsAsync(string userId, EditUserDetailsDto editUserDetailsDto);
		Task<AppUser> DeleteUser(string userId);

	}
}