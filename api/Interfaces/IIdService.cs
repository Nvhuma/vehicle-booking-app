using api.Models;

namespace api.Interfaces
{
    public interface IIdService
    {
        Task<AppUser> ExtractIdDetailsAsync(string idNumber);
    }

    
}