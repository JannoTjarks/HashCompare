using System;
using System.IO;
using System.Security.Cryptography;
using HashCompare.Language;

namespace HashCompare
{
    // author: Janno Tjarks (janno.tjarks@hotmail.de)
    // version: Alpha 1.2
    // date: 01.04.2018

    class HashCompare
    {
        // Declaration Language
        private static LanguageSelect language = null;     

        // Main-method
        static void Main(string[] args)
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

        private static void Greeting()
        {
            // var greeting = "Moin!";
            Console.WriteLine("{0}", language.Greeting);
        }

        // Read the Hash from the website and removed the blank
        private static string GetHashFromWebsite()
        {
            //var giveHash = "Wie lautet der Hashwert, den die Download-Seite nennt?";
            Console.WriteLine("{0}", language.GiveHash);
            var websiteHash = Console.ReadLine();
            return websiteHash.Replace(" ", "");
        }

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
                }
                catch
                {
                    Console.WriteLine("{0}", language.PathError);
                }
            }

            return fileStream;
        }

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
                    case "SHA-1":
                        hash = Hash.StreamToHash(new SHA1Managed(), fileStream);
                        correctMethod = true;
                        break;
                    case "SHA-256":
                        hash = Hash.StreamToHash(new SHA256Managed(), fileStream);
                        correctMethod = true;
                        break;
                    case "SHA-384":
                        hash = Hash.StreamToHash(new SHA384Managed(), fileStream);
                        correctMethod = true;
                        break;
                    case "SHA-512":
                        hash = Hash.StreamToHash(new SHA512Managed(), fileStream);
                        correctMethod = true;
                        break;
                    default:
                        break;
                }
                
                if (hash != String.Empty)
                {
                    correctMethod = true;
                }
                else
                {
                    Console.WriteLine("{0}", language.HashError);
                }
            }

            return hash;
        }

        private static void ResultOfComparison(string websiteHash, string fileHash)
        {
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

        private static void Close()
        {
            var close = "Beliebige Taste zum Beenden...";
            Console.WriteLine("{0}", close);
            Console.ReadKey(true);
        }
    }
}