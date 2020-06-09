using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace client_desktop
{
    class Hash
    {
        public static byte[] GenerateHash(byte[] plainText)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            return algorithm.ComputeHash(plainText);
        }
    }
}
