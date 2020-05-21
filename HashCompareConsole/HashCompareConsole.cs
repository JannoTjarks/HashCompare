using System;
using System.IO;
using System.Security.Cryptography;
using McMaster.Extensions.CommandLineUtils;
using HashCompareLib.LanguageSelection;

namespace HashCompareLib
{
    /// <summary>
    /// This is the main class and performs all inputs and outputs.
    /// </summary>
    public class HashCompare
    {
        #region private variables        
        // Declaration Language        v
        private static Language language = null;

        #endregion

        #region methods
        // Main-method
        private static int Main(string[] args)
        {
            // Define String for app-Option.
            var argumentLanguageString = "The selected language package. " +
                "English (en), German (de) and Low German (platt) are " +
                "available.";
            var argumentHashFromWebsiteString = "The Hash-Value that the " +
                "download-site is calling.";
            var argumentFileString = "Path to the downloaded file.";
            var argumentHashMethodString = "The wanted hash-method (MD5, " +
                "SHA-1, SHA-256, SHA-384, SHA-512).";

            // Define CommandLineApplication
            var app = new CommandLineApplication();
            app.HelpOption("-?|--help");
            var argumentLanguage = app.Option("-l|--language <string>", 
                argumentLanguageString, CommandOptionType.SingleValue);
            var argumentHashFromWebsite = app.Option("-h|--hash <string>", 
                argumentHashFromWebsiteString, CommandOptionType.SingleValue);
            var argumentFile = app.Option("-f|--file <string>", 
                argumentFileString, CommandOptionType.SingleValue);            
            var argumentHashMethod = app.Option("-m|--hashmethod <string>", 
                argumentHashMethodString, CommandOptionType.SingleValue);

            // Start CommandLineApplication
            app.OnExecute(() =>
            {                
                // Get language argument and and loads a language package
                var languageValue = argumentLanguage.HasValue() ? argumentLanguage.Value() : "en";
                language = LanguageReader.Read(languageValue);
                
                // Write Greeting
                Greet();

                // Get the hash-value argument
                var websiteHash = argumentHashFromWebsite.HasValue() ? argumentHashFromWebsite.Value() : GetHashFromWebsite();

                // Get the file-location argument
                var fileLocation = argumentFile.HasValue() ? argumentFile.Value() : GetFileLocation();
                
                // Get the hash-method argument
                var hashMethod = argumentHashMethod.HasValue() ? argumentHashMethod.Value() : GetHashMethod();                                                           

                // Get Hash from File
                var fileHash = GetHashFromFile(hashMethod, GetFileStream(fileLocation));

                // Show result of comparison
                CompareTheResult(websiteHash, fileHash);

                // Close the application
                Close();

                return 0;
            });
            
            try
            {
                return app.Execute(args);
            }
            catch (UnrecognizedCommandParsingException)
            {
                Console.WriteLine("{0}", language.UnrecognizedOption);                
                return 0;
            }

        }

        // Writes a greeting
        private static void Greet()
        {
            Console.WriteLine("{0}", language.Greeting);
            Console.Write("\n");
        }

        // Reads the Hash from the website and removes the blank
        private static string GetHashFromWebsite()
        {
            Console.WriteLine("{0}", language.GiveHash);
            var websiteHash = Console.ReadLine();
            Console.Write("\n");
            
            return websiteHash.Replace(" ", "");
        }

        // Reads the filepath
        private static string GetFileLocation()
        {            
            Console.WriteLine("{0}", language.GivePath);
            string fileLocation = Console.ReadLine();
            Console.Write("\n");

            return fileLocation;
        }

        // Creates a filestream
        private static FileStream GetFileStream(string fileLocation)
        {            
            FileStream fileStream = null;            
            var fileReadable = false;
            while (!fileReadable)
            {
                try
                {                    
                    var file = new FileInfo(fileLocation);
                    fileStream = file.Open(FileMode.Open);
                    fileReadable = true;
                }
                catch
                {
                    Console.WriteLine("{0}", language.PathError);
                    fileLocation = Console.ReadLine();
                    Console.Write("\n");
                }
            }            

            return fileStream;
        }

        // Reads hash method
        private static string GetHashMethod()
        {
            Console.WriteLine("{0}", language.GiveHashMethod);
            var method = String.Empty;
            var correctMethod = false;
            while (!correctMethod)
            {
                method = Console.ReadLine();                
                switch (method.Replace(" ", ""))
                {
                    case "MD5":
                        correctMethod = true;
                        break;
                    case "SHA-1":
                        correctMethod = true;
                        break;
                    case "SHA-256":
                        correctMethod = true;
                        break;
                    case "SHA-384":
                        correctMethod = true;
                        break;
                    case "SHA-512":
                        correctMethod = true;
                        break;
                    default:
                        break;
                }

                Console.Write("\n");

                if (!correctMethod)
                {
                    Console.WriteLine("{0}", language.HashError);
                    Console.Write("\n");
                }
            }

            return method;
        }

        // Returns the hash as string
        private static string GetHashFromFile(string method, FileStream fileStream)
        {            
            var hash = String.Empty;
            var correctMethod = false;
            while (!correctMethod)
            {                
                switch (method.Replace(" ", ""))
                {
                    case "MD5":
                        hash = Hash.GetHashAsString(MD5.Create(), fileStream);
                        break;
                    case "SHA-1":
                        hash = Hash.GetHashAsString(SHA1.Create(), fileStream);
                        break;
                    case "SHA-256":
                        hash = Hash.GetHashAsString(SHA256.Create(), fileStream);
                        break;
                    case "SHA-384":
                        hash = Hash.GetHashAsString(SHA384.Create(), fileStream);
                        break;
                    case "SHA-512":
                        hash = Hash.GetHashAsString(SHA512.Create(), fileStream);
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
                    method = Console.ReadLine();
                    Console.Write("\n");
                }                
            }

            return hash;
        }

        // Compares the hash with the string from the website 
        private static void CompareTheResult(string websiteHash, string fileHash)
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