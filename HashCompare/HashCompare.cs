using System;
using System.IO;
using System.Security.Cryptography;
using HashCompare.Language;

namespace HashCompare
{
    // author: Janno Tjarks (janno.tjarks@hotmail.de)
    // version: 1.0
    // date: 2018-04-14
    /// <summary>
    /// This is the main class and performs all inputs and outputs.
    /// </summary>
    public class HashCompare
    {
        #region private variables
        // Declaration Language        
        private static LanguageSelected language = null;

        #endregion

        #region methods
        // Main-method
        private static void Main(string[] args)
        {
            // Get Language
            GetLanguage(args);

            // Write Greeting
            Greeting();

            // Get Hash from the website
            var websiteHash = GetHashFromWebsite();

            // Reading the file
            var fileStream = GetFileStream();

            // Get Hash from File
            var fileHash = GetHashFromFile(fileStream);

            // Show result of comparison
            ResultOfComparison(websiteHash, fileHash);

            // Close the application
            Close();
        }

        // Reads the start arguments and loads a language package
        private static void GetLanguage(string[] args)
        {            
            // Check arguments
            if (args.Length == 1)
            {
                language = LanguageRead.Read(args[0]);
            }
            else
            {
                language = LanguageRead.Read(null);
            }
        }

        // Writes a greeting
        private static void Greeting()
        {
            Console.WriteLine("{0}", language.Greeting);
        }

        // Reads the Hash from the website and removes the blank
        private static string GetHashFromWebsite()
        {
            Console.WriteLine("\n{0}", language.GiveHash);
            var websiteHash = Console.ReadLine();
            Console.Write("\n");
            return websiteHash.Replace(" ", "");
        }

        // Reads the filepath and creates a filestream
        private static FileStream GetFileStream()
        {
            FileStream fileStream = null;
            Console.WriteLine("{0}", language.GivePath);
            var fileReadable = false;
            while (!fileReadable)
            {
                try
                {
                    var path = String.Empty;
                    path = Console.ReadLine();

                    var file = new FileInfo(path);
                    fileStream = file.Open(FileMode.Open);
                    fileReadable = true;
                    Console.Write("\n");
                }
                catch
                {
                    Console.WriteLine("\n{0}", language.PathError);
                }
            }            

            return fileStream;
        }

        // Reads hash method and returns the hash as string
        private static string GetHashFromFile(FileStream fileStream)
        {
            Console.WriteLine("{0}", language.GiveHashMethod);
            var hash = String.Empty;
            var correctMethod = false;
            while (!correctMethod)
            {
                var method = Console.ReadLine();
                switch (method.Replace(" ", ""))
                {
                    case "MD5":
                        hash = Hash.StreamToHash(MD5.Create(), fileStream);
                        correctMethod = true;
                        break;
                    case "SHA-1":
                        hash = Hash.StreamToHash(SHA1.Create(), fileStream);
                        correctMethod = true;
                        break;
                    case "SHA-256":
                        hash = Hash.StreamToHash(SHA256.Create(), fileStream);
                        correctMethod = true;
                        break;
                    case "SHA-384":
                        hash = Hash.StreamToHash(SHA384.Create(), fileStream);
                        correctMethod = true;
                        break;
                    case "SHA-512":
                        hash = Hash.StreamToHash(SHA512.Create(), fileStream);
                        correctMethod = true;
                        break;
                    default:
                        break;
                }

                if (hash != String.Empty)
                {
                    correctMethod = true;
                    Console.Write("\n");
                }
                else
                {
                    Console.WriteLine("\n{0}", language.HashError);
                }
            }

            return hash;
        }

        // Compares the hash with the string from the website 
        private static void ResultOfComparison(string websiteHash, string fileHash)
        {
            Console.WriteLine("{0}:\t{1}\n{2}:\t{3}\n", language.WebsitheHash, websiteHash,
                language.FileHash, fileHash);
            Console.Write("{0}", language.ResultBegin);
            var resultEnd = String.Empty;
            if (websiteHash == fileHash)
            {
                resultEnd = language.ResultEndPositiv;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                resultEnd = language.ResultEndNegativ;
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine("{0}", resultEnd);
            Console.ResetColor();

        }

        // Waits for a key and closes the application then. 
        private static void Close()
        {
            Console.WriteLine("\n{0}", language.Close);
            Console.ReadKey(true);
        }

        #endregion
    }
}