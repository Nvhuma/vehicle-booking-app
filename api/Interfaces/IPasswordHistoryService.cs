using api.Models;

namespace api.Interfaces
{
    public interface IPasswordHistoryService
    {
        Task<UserPasswordHistory> AddPasswordAsync(string userID, string hashedPassword);
        Task<bool> IsPasswordReusedAsync(string userId, string hashedPassword, TimeSpan period);
    }
}