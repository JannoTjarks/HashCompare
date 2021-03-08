using System;
using System.IO;
using McMaster.Extensions.CommandLineUtils;
using HashCompareLib;
using System.Security.Cryptography;

namespace HashCompareConsole
{
    public class HashCompare
    {
        // Declaration Language        
        private static Language language;

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
                language = Language.Instance(languageValue);

                var comparer = new Comparer(language);

                // Write greeting
                comparer.Greet();

                // Get the hash-value argument
                var websiteHash = argumentHashFromWebsite.HasValue() ? argumentHashFromWebsite.Value() : comparer.GetHashFromWebsite();

                // Get the file-location argument
                var fileLocation = argumentFile.HasValue() ? argumentFile.Value() : comparer.GetFileLocation();

                // Get filestream from file
                FileStream fileStream = null;
                while (fileStream == null)
                {
                    fileStream = IO.GetFileStream(fileLocation);                    
                    if (fileStream == null)
                    {                        
                        fileLocation = comparer.GetPathError();                        
                    }
                }

                // Get the hash-algorithm argument as string
                var hashAlgorithmString = argumentFile.HasValue() ? argumentFile.Value() : comparer.GetHashAlgorithm();

                // Get hash-algorithm
                HashAlgorithm hashAlgorithm = null;                
                while (hashAlgorithm == null)
                {
                    hashAlgorithm = Hash.GetHashAlgorithm(hashAlgorithmString);
                    if (hashAlgorithm == null)
                    {
                        hashAlgorithmString = comparer.GetHashError();
                    }                    
                }

                // Get Hash from file
                var fileHash = Hash.GetHashAsString(hashAlgorithm, fileStream);

                // Compare the hashes
                var hashIsIdentical = IO.CompareTheResult(websiteHash, fileHash);

                // Show result of comparison
                comparer.CompareTheResult(hashIsIdentical, websiteHash, fileHash);

                // Close the application
                comparer.Close();

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
    }
}