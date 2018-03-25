using System;
using System.IO;
using System.Security.Cryptography;

namespace HashCompare
{
    // author: Janno Tjarks (janno.tjarks@hotmail.de)
    // version: Alpha 1.1
    // date: 25.03.2018

    class Program
    {
        // Main-method
        static void Main(string[] args)
        {
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

        private static void Greeting()
        {
            var greeting = "Moin!";
            Console.WriteLine("{0}", greeting);
        }

        // Read the Hash from the website and removed the blank
        private static string GetHashFromWebsite()
        {
            var giveHash = "Wie lautet der Hashwert, den die Download-Seite nennt?";
            Console.WriteLine("{0}", giveHash);
            var websiteHash = Console.ReadLine();
            return websiteHash.Replace(" ", "");
        }

        private static FileStream GetFileStream()
        {
            FileStream fileStream = null;
            var givePath = "Geben sie den Dateipfad ein:";
            Console.WriteLine("{0}", givePath);
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
                    var readError = "Es konnte nicht auf die Datei zugegriffen werden!" +
                        "\nGeben sie den Dataipfad erneut ein:";
                    Console.WriteLine("{0}", readError);
                }
            }

            return fileStream;
        }

        private static string GetHashFromFile(FileStream fileStream)
        {
            // Check the hash-method input and hash
            var giveHash = "Um welches Hashverfahren handelt es sich? (SHA-1, SHA-256, SHA-384, SHA-512)";
            Console.WriteLine("{0}", giveHash);
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
                    var hashError = "Eingabe des Hash-Types ist fehlerhaft. Bitte nochmal eingeben! " +
                        "\n(SHA-1, SHA-256, SHA-384, SHA-512)";
                    Console.WriteLine("{0}", hashError);
                }
            }

            return hash;
        }

        private static void ResultOfComparison(string websiteHash, string fileHash)
        {
            var resultBegin = "Die Strings sind ";
            Console.Write("{0}", resultBegin);
            var resultEnd = String.Empty;
            if (websiteHash == fileHash)
            {
                resultEnd = "identisch!";
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                resultEnd = "unterschiedlich!";
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