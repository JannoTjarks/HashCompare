using System;
using System.IO;
using System.Security.Cryptography;

namespace HashCompare
{
    static class Hash
    {
        // Hashed the stream with the chosed hash-method
        public static string StreamToHash(SHA1 hashMethod, FileStream fileStream)
        {
            var hash = hashMethod.ComputeHash(fileStream);
            return GetHashAsString(hash, fileStream);
        }

        public static string StreamToHash(SHA256 hashMethod, FileStream fileStream)
        {
            var hash = hashMethod.ComputeHash(fileStream);
            return GetHashAsString(hash, fileStream);
        }

        public static string StreamToHash(SHA384 hashMethod, FileStream fileStream)
        {
            var hash = hashMethod.ComputeHash(fileStream);
            return GetHashAsString(hash, fileStream);
        }

        public static string StreamToHash(SHA512 hashMethod, FileStream fileStream)
        {
            var hash = hashMethod.ComputeHash(fileStream);
            return GetHashAsString(hash, fileStream);
        }

        // Dispose the stream and give hash as string
        private static string GetHashAsString(byte[] hash, FileStream fileStream)
        {
            fileStream.Dispose();
            return ByteArrayToString(hash);
        }

        // Convert a byte-array to a string with lowercase
        private static string ByteArrayToString(byte[] array)
        {
            var hash = String.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                hash += (String.Format("{0:X2}", array[i]));
            }

            return hash.ToLower(); ;
        }
    }
}