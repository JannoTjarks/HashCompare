using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HashCompare
{
    static class Hash
    {
        public static byte[] StreamToHash(SHA1 hashMethod, FileStream fileStream)
        {
            var downloadHash = hashMethod.ComputeHash(fileStream);
            return downloadHash;
        }

        public static byte[] StreamToHash(SHA256 hashMethod, FileStream fileStream)
        {
            var downloadHash = hashMethod.ComputeHash(fileStream);
            return downloadHash;
        }

        public static byte[] StreamToHash(SHA384 hashMethod, FileStream fileStream)
        {
            var downloadHash = hashMethod.ComputeHash(fileStream);
            return downloadHash;
        }

        public static byte[] StreamToHash(SHA512 hashMethod, FileStream fileStream)
        {
            var downloadHash = hashMethod.ComputeHash(fileStream);
            return downloadHash;
        }
    }
}
