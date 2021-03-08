using HashCompareLib;
using System;
using System.IO;
using System.Security.Cryptography;

namespace HashCompareConsole
{
    class Comparer
    {
        private Language language;

        public Comparer(Language language)
        {
            this.language = language;
        }

        // Writes a greeting
        internal void Greet()
        {
            Console.WriteLine("{0}", language.Greeting);
            Console.Write("\n");
        }

        // Reads the Hash from the website and removes the blank
        internal string GetHashFromWebsite()
        {
            Console.WriteLine("{0}", language.GiveHash);
            var websiteHash = Console.ReadLine();
            Console.Write("\n");

            return websiteHash.Replace(" ", "");
        }

        // Reads the filepath
        internal string GetFileLocation()
        {
            Console.WriteLine("{0}", language.GivePath);
            string fileLocation = Console.ReadLine();
            Console.Write("\n");

            return fileLocation;
        }        

        internal string GetPathError()
        {
            Console.WriteLine("{0}", language.PathError);
            var fileLocation = Console.ReadLine();
            Console.Write("\n");

            return fileLocation;
        }

        // Reads hash method
        internal string GetHashAlgorithm()
        {
            Console.WriteLine("{0}", language.GiveHashMethod);           
            var method = Console.ReadLine();                            

            return method.Replace(" ", "");
        }

        internal string GetHashError()
        {
            Console.WriteLine("{0}", language.HashError);
            var hashAlgorithm = Console.ReadLine();
            Console.Write("\n");

            return hashAlgorithm;
        }

        // Compares the hash with the string from the website 
        internal void CompareTheResult(bool isIdentical, string websiteHash, string fileHash)
        {
            Console.WriteLine("{0}:\t{1}\n{2}:\t{3}\n", language.WebsiteHash, 
                websiteHash, language.FileHash, fileHash);
            Console.Write("{0}", language.ResultBegin);
            var resultEnd = String.Empty;
            if (isIdentical)
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
        internal void Close()
        {
            Console.WriteLine("\n{0}", language.Close);
            Console.ReadKey(true);
        }
    }
}