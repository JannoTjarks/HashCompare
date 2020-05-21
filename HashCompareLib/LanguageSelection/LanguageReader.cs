using System.Globalization;
using System.IO;
using Newtonsoft.Json;

namespace HashCompareLib.LanguageSelection
{
    // author: Janno Tjarks (janno.tjarks@hotmail.de)
    // version: 2.0
    // date: 2019-05-22
    /// <summary>
    /// This class sets all strings for the output.
    /// </summary>
    public class LanguageReader
    {
        public static Language Read(string languageId)
        {
            if (languageId == "de" || CultureInfo.CurrentCulture.ToString() == "de-DE" && languageId == null)
            {
                return JsonConvert.DeserializeObject<Language>(File.ReadAllText(@"C:\Users\Janno\OneDrive\Programmierung\HashCompare\HashCompareLib\LanguagePack\de.json")); ; ;
            }
            else if (languageId == "platt")
            {
                return JsonConvert.DeserializeObject<Language>(File.ReadAllText(@"C:\Users\Janno\OneDrive\Programmierung\HashCompare\HashCompareLib\LanguagePack\platt.json")); ;
            }
            else
            {                
                return JsonConvert.DeserializeObject<Language>(File.ReadAllText(@"C:\Users\Janno\OneDrive\Programmierung\HashCompare\HashCompareLib\LanguagePack\en.json")); ;
            }
        }
    }
}