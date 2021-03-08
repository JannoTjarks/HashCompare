using Newtonsoft.Json;
using System;
using System.IO;

namespace HashCompareLib
{
    public class Language
    {        
        private string unrecognizedOption = String.Empty;
        private string greeting = String.Empty;
        private string giveHash = String.Empty;
        private string givePath = String.Empty;
        private string pathError = String.Empty;
        private string giveHashMethod = String.Empty;
        private string hashError = String.Empty;
        private string websiteHash = String.Empty;
        private string fileHash = String.Empty;
        private string resultBegin = String.Empty;
        private string resultEndPositiv = String.Empty;
        private string resultEndNegativ = String.Empty;
        private string close = String.Empty;
        private static Language instance;        

        public string UnrecognizedOption { get => unrecognizedOption; set => unrecognizedOption = value; }
        public string Greeting { get => greeting; set => greeting = value; }
        public string GiveHash { get => giveHash; set => giveHash = value; }
        public string GivePath { get => givePath; set => givePath = value; }
        public string PathError { get => pathError; set => pathError = value; }
        public string GiveHashMethod { get => giveHashMethod; set => giveHashMethod = value; }
        public string HashError { get => hashError; set => hashError = value; }
        public string WebsiteHash { get => websiteHash; set => websiteHash = value; }
        public string FileHash { get => fileHash; set => fileHash = value; }
        public string ResultBegin { get => resultBegin; set => resultBegin = value; }
        public string ResultEndPositiv { get => resultEndPositiv; set => resultEndPositiv = value; }
        public string ResultEndNegativ { get => resultEndNegativ; set => resultEndNegativ = value; }
        public string Close { get => close; set => close = value; }

        // Singelton
        public static Language Instance(string languageId)
        {
            if (instance == null)
            {
                if (languageId == "de")
                {
                    instance = JsonConvert.DeserializeObject<Language>(File.ReadAllText(@"C:\Users\Janno\OneDrive\Programmierung\HashCompare\HashCompareLib\LanguagePack\de.json")); ; ;
                }
                else if (languageId == "platt")
                {
                    instance = JsonConvert.DeserializeObject<Language>(File.ReadAllText(@"C:\Users\Janno\OneDrive\Programmierung\HashCompare\HashCompareLib\LanguagePack\platt.json")); ;
                }
                else
                {
                    instance = JsonConvert.DeserializeObject<Language>(File.ReadAllText(@"C:\Users\Janno\OneDrive\Programmierung\HashCompare\HashCompareLib\LanguagePack\en.json")); ;
                }

                
            }

            return instance;
        }
    }
}