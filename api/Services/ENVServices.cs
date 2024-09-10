using api.Interfaces;

namespace api.Services
{
    public class ENVServices : IENVServices
    {
        public string GetConnectionString()
        {
            // Get connection string from environment variable or fallback to default
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is not defined in the environment variables.");
            }
            return connectionString;
        }

        public string GetSignInKey()
    {
        // Get sign In Key string from environment variable or fallback to default
        var signInKey = Environment.GetEnvironmentVariable("SIGN_IN_KEY");
        if (string.IsNullOrEmpty(signInKey))
        {
            throw new InvalidOperationException("sign in key string is not defined in the environment variables.");
        }
        return signInKey;
    }
    }
}