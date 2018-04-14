using System;
using System.IO;
using System.Security.Cryptography;

namespace HashCompare
{
    // author: Janno Tjarks (janno.tjarks@hotmail.de)
    // version: 1.0
    // date: 2018-04-14
    /// <summary>
    /// This class performs all tasks concerning the hashing.
    /// </summary>
    static class Hash
    {
        #region methods

        // Hashs the stream with the chosed hash-method MD5
        public static string StreamToHash(MD5 hashMethod, FileStream fileStream)
        {
            var hash = hashMethod.ComputeHash(fileStream);
            return GetHashAsString(hash, fileStream);
        }

        // Hashs the stream with the chosed hash-method SHA1
        public static string StreamToHash(SHA1 hashMethod, FileStream fileStream)
        {
            var hash = hashMethod.ComputeHash(fileStream);
            return GetHashAsString(hash, fileStream);
        }

        // Hashs the stream with the chosed hash-method SHA256
        public static string StreamToHash(SHA256 hashMethod, FileStream fileStream)
        {
            var hash = hashMethod.ComputeHash(fileStream);
            return GetHashAsString(hash, fileStream);
        }

        // Hashs the stream with the chosed hash-method SHA384
        public static string StreamToHash(SHA384 hashMethod, FileStream fileStream)
        {
            var hash = hashMethod.ComputeHash(fileStream);
            return GetHashAsString(hash, fileStream);
        }

        // Hashs the stream with the chosed hash-method SHA512
        public static string StreamToHash(SHA512 hashMethod, FileStream fileStream)
        {
            var hash = hashMethod.ComputeHash(fileStream);
            return GetHashAsString(hash, fileStream);
        }

        // Disposes the stream and gives hash as string
        private static string GetHashAsString(byte[] hash, FileStream fileStream)
        {
            fileStream.Dispose();
            return ByteArrayToString(hash);
        }

        // Converts a byte-array to a string with lowercase
        private static string ByteArrayToString(byte[] array)
        {
            var hash = String.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                hash += (String.Format("{0:X2}", array[i]));
            }

            return hash.ToLower(); ;
        }

        #endregion
    }
}