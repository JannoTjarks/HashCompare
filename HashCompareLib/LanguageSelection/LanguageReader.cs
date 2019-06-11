using System.Globalization;
using HashCompareLib.LanguagePack;

namespace HashCompareLib.LanguageSelection
{
    // author: Janno Tjarks (janno.tjarks@hotmail.de)
    // version: 1.0
    // date: 2018-04-14
    /// <summary>
    /// This class sets all strings for the output.
    /// </summary>
    public class LanguageReader
    {
        public static Language Read(string languageId)
        {
            #region methods
            if (languageId == "de" || CultureInfo.CurrentCulture.ToString() == "de-DE" && languageId == null)
            {
                var language = new Language
                {
                    UnrecognizedOption = de.UnrecognizedOption,
                    Greeting = de.Greeting,
                    GiveHash = de.GiveHash,
                    GivePath = de.GivePath,
                    PathError = de.PathError,
                    GiveHashMethod = de.GiveHashMethod,
                    HashError = de.HashError,
                    WebsitheHash = de.WebsiteHash,
                    FileHash = de.FileHash,
                    ResultBegin = de.ResultBegin,
                    ResultEndPositiv = de.ResultEndPositiv,
                    ResultEndNegativ = de.ResultEndNegativ,
                    Close = de.Close
                };

                return language;
            }
            else if (languageId == "platt")
            {
                var language = new Language
                {
                    UnrecognizedOption = platt.UnrecognizedOption,
                    Greeting = platt.Greeting,
                    GiveHash = platt.GiveHash,
                    GivePath = platt.GivePath,
                    PathError = platt.PathError,
                    GiveHashMethod = platt.GiveHashMethod,
                    HashError = platt.HashError,
                    WebsitheHash = platt.WebsiteHash,
                    FileHash = platt.FileHash,
                    ResultBegin = platt.ResultBegin,
                    ResultEndPositiv = platt.ResultEndPositiv,
                    ResultEndNegativ = platt.ResultEndNegativ,
                    Close = platt.Close
                };

                return language;
            }
            else
            {
                var language = new Language
                {
                    UnrecognizedOption = en.UnrecognizedOption,
                    Greeting = en.Greeting,
                    GiveHash = en.GiveHash,
                    GivePath = en.GivePath,
                    PathError = en.PathError,
                    GiveHashMethod = en.GiveHashMethod,
                    HashError = en.HashError,
                    WebsitheHash = en.WebsiteHash,
                    FileHash = en.FileHash,
                    ResultBegin = en.ResultBegin,
                    ResultEndPositiv = en.ResultEndPositiv,
                    ResultEndNegativ = en.ResultEndNegativ,
                    Close = en.Close
                };

                return language;
            }

            #endregion
        }
    }
}