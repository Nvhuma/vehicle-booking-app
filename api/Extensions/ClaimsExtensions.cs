using System.Security.Claims;

namespace api.Extensions
{
    public static class ClaimsExtensions
    {
        public static string GetUserEmail(this ClaimsPrincipal user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "ClaimsPrincipal cannot be null");
            }

            /*  Incase the new claims method does not work  */
            //  var emailClaim = user.Claims.SingleOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
            var emailClaim = user.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Email);
            if (emailClaim == null)
            {
                throw new InvalidOperationException("Email claim not found");
            }
            return emailClaim.Value;
        }

        public static string GetUserName(this ClaimsPrincipal user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "ClaimsPrincipal cannot be null");
            }

            /*  Incase the new claims method does not work  */
            //  var emailClaim = user.Claims.SingleOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname");
            var userNameClaim = user.Claims.SingleOrDefault(x => x.Type == ClaimTypes.GivenName);
            if (userNameClaim == null)
            {
                throw new InvalidOperationException("Username claim not found");
            }
            return userNameClaim.Value;
        }
    }
}
