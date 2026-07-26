using System.Security.Cryptography;
using System.Text;
using api.Interfaces;

namespace api.Services
{

    public class EncryptionService : IEncryptionService
    {
        private readonly byte[] _key;

        public EncryptionService()
        {
            string encryptionKey = Environment.GetEnvironmentVariable("CARD_ENCRYPTION_KEY");
            _key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(encryptionKey)); // Produces a 32-byte (256-bit) key
        }

        public string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = new byte[16]; // Initialization vector (IV). Use a secure random value in production.

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                    byte[] cipherBytes = encryptor.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
                    return Convert.ToBase64String(cipherBytes);
                }
            }
        }

        public string Decrypt(string cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = new byte[16]; // Initialization vector (IV). Use a secure random value in production.

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    byte[] cipherBytes = Convert.FromBase64String(cipherText);
                    byte[] plainTextBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                    return Encoding.UTF8.GetString(plainTextBytes);
                }
            }
        }
    }
}