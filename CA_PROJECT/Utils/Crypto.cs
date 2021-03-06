using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace APIGateway.Utils
{
    public class Crypto
    {
        static public string Sha256(string str)
        {
            SHA256 sha256 = SHA256.Create();

            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
