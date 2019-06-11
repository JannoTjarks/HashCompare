using System;
using System.IO;
using System.Security.Cryptography;

namespace HashCompareLib
{
    // author: Janno Tjarks (janno.tjarks@hotmail.de)
    // version: 1.0
    // date: 2018-04-14
    /// <summary>
    /// This class performs all tasks concerning the hashing.
    /// </summary>
    public static class Hash
    {
        #region methods
        // Hash the stream with the chosen hash-method with the given method
        public static string GetHashAsString(HashAlgorithm hashMethod, FileStream fileStream)
        {
            var hash = hashMethod.ComputeHash(fileStream);
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

        #endregion
    }
}