using System;
using System.IO;
using System.Security.Cryptography;

namespace HashCompare
{
    // author: Janno Tjarks (janno.tjarks@hotmail.de)
    // version: Alpha 1.0
    // date: 25.03.2018

    class Program
    {
        // Main-method
        static void Main(string[] args)
        {
            // Greeting
            Console.WriteLine("Moin!");

            // Hash from the website
            Console.WriteLine("Hash der Download-Seite");
            var websiteHash = Console.ReadLine();
            websiteHash = websiteHash.Replace(" ", "");

            // Reading the file
            FileStream fileStream = null;
            Console.WriteLine("Geben sie den Dateipfad ein:");
            var fileReadable = false;
            while (!fileReadable)
            {
                try
                {
                    var path = Console.ReadLine();
                    var file = new FileInfo(path);
                    fileStream = file.Open(FileMode.Open);
                    fileReadable = true;
                }
                catch
                {
                    Console.WriteLine("Es konnte nicht auf die Datei zugegriffen werden!" +
                        "\n Geben sie den Dataipfad erneut ein:");
                }
            }

            // Chose hash-method
            Console.WriteLine("Welches Hashverfahren soll angewendet werden? (SHA-1, SHA-256, SHA-384, SHA-512)");
            var method = Console.ReadLine();

            // Check the hash-method input and hash
            var hash = String.Empty;
            var correctMethod = false;
            while (!correctMethod)
            {
                switch (method.Replace(" ", ""))
                {
                    case "SHA-1":
                        hash = ByteArrayToString(Hash.StreamToHash(new SHA1Managed(), fileStream));
                        correctMethod = true;
                        break;
                    case "SHA-256":
                        hash = ByteArrayToString(Hash.StreamToHash(new SHA256Managed(), fileStream));
                        correctMethod = true;
                        break;
                    case "SHA-384":
                        hash = ByteArrayToString(Hash.StreamToHash(new SHA384Managed(), fileStream));
                        correctMethod = true;
                        break;
                    case "SHA-512":
                        hash = ByteArrayToString(Hash.StreamToHash(new SHA512Managed(), fileStream));
                        correctMethod = true;
                        break;
                    default:
                        break;
                }

                if (hash != String.Empty)
                {
                    fileStream.Dispose();
                    correctMethod = true;
                }
                else
                {
                    Console.WriteLine("Eingabe des Hash-Types ist fehlerhaft. Bitte nochmal eingeben! " +
                        "\n(SHA-1, SHA-256, SHA-384, SHA-512)");
                }
            }

            // Comparison
            if (hash == websiteHash)
            {
                Console.WriteLine("Die Strings sind identisch!");
            }
            else
            {
                Console.WriteLine("Die Strings sind unterschiedlich!");
            }

            Console.ReadKey();
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