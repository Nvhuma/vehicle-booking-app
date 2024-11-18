

namespace api.Interfaces
{
	using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public interface IEncryptionService
    {
        string Encrypt(string plainText);
        string Decrypt(string cipherText);
    }
}