

namespace api.Interfaces
{
	using api.Models;
    public interface IIdService
    {
        Task<AppUser> ExtractIdDetailsAsync(string idNumber);
    }

    
}