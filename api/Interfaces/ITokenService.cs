
using api.Models;

namespace api.Interfaces
{
    public interface ITokenService
    {
      public  string CreateToken(AppUser user, IList<string> roles);
    }
}