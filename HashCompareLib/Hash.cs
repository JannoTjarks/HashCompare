using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace HashCompareLib
{
    // author: Janno Tjarks (janno.tjarks@hotmail.de)
    // version: 1.0
    // date: 2020-05-22
    /// <summary>
    /// This class performs all tasks concerning the hashing.
    /// </summary>
    public static class Hash
    {
        private static List<String> hashMethods = new List<String>()
        {
            "MD5",
            "SHA-1",
            "SHA-256",
            "SHA-384",
            "SHA-512"
        };

        public static List<String> HashMethods { get => hashMethods; }

        // Hash the stream with the chosen hash-method with the given method

        public static HashAlgorithm GetHashAlgorithm(String hashMethod)
        {
            HashAlgorithm hashAlgorithm = null;
            switch (hashMethod)
            {
                case "MD5":
                    hashAlgorithm = MD5.Create();
                    break;
                case "SHA-1":
                    hashAlgorithm = SHA1.Create();
                    break;
                case "SHA-256":
                    hashAlgorithm = SHA256.Create();
                    break;
                case "SHA-384":
                    hashAlgorithm = SHA384.Create();
                    break;
                case "SHA-512":
                    hashAlgorithm = SHA512.Create();
                    break;
                default:
                    break;
            }
            
            return hashAlgorithm;                            
        }

        public static string GetHashAsString(HashAlgorithm hashAlgorithm, FileStream fileStream)
        {
            var hash = hashAlgorithm.ComputeHash(fileStream);
            fileStream.Dispose();
            
            return ConvertByteArrayToString(hash);
        }

		// Hash the string with the chosen hash-method with the given method
        public static string GetHashAsString(HashAlgorithm hashMethod, String hashString)
        {
            var hashStringAsArray = new byte[hashString.Length];

            for (int i = 0; i < hashString.Length; i++) {
                hashStringAsArray[i] = Convert.ToByte(hashString[i]);
            }

            var hash = hashMethod.ComputeHash(hashStringAsArray);
            
            return ConvertByteArrayToString(hash);
        }

        // Converts the hash byte-array to a string with lowercase and return that
        private static string ConvertByteArrayToString(byte[] array)
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