
namespace api.Interfaces
{
	using api.Models;
	public interface ITokenService
	{
		public string CreateToken(AppUser user, IList<string> roles);
	}
}