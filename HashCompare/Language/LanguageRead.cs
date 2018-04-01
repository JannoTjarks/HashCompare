using HashCompare.LanguagePack;

namespace HashCompare.Language
{
    public class LanguageRead
    {
        public static LanguageSelect Read(string languageId)
        {
            if (languageId == "de")
            {
                var language = new LanguageSelect
                {                    
                    Greeting = de.Greeting,
                    GiveHash = de.GiveHash,
                    GivePath = de.GivePath,
                    PathError = de.PathError,
                    GiveHashMethod = de.GiveHashMethod,
                    HashError = de.HashError,
                    ResultBegin = de.ResultBegin,
                    ResultEndPositiv = de.ResultEndPositiv,
                    ResultEndNegativ = de.ResultEndNegativ,
                    Close = de.Close
                };

                return language;
            }

            else
            {
                var language = new LanguageSelect
                {
                    Greeting = en.Greeting,
                    GiveHash = en.GiveHash,
                    GivePath = en.GivePath,
                    PathError = en.PathError,
                    GiveHashMethod = en.GiveHashMethod,
                    HashError = en.HashError,
                    ResultBegin = en.ResultBegin,
                    ResultEndPositiv = en.ResultEndPositiv,
                    ResultEndNegativ = en.ResultEndNegativ,
                    Close = en.Close
                };

                return language;
            }
        }
    }
}