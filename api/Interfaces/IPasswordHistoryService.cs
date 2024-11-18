

namespace api.Interfaces
{
	using api.Models;
    public interface IPasswordHistoryService
    {
        Task<UserPasswordHistory> AddPasswordAsync(string userID, string hashedPassword);
        Task<bool> IsPasswordReusedAsync(string userId, string hashedPassword, TimeSpan period);
    }
}