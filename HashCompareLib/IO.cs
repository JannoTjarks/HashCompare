using System.IO;

namespace HashCompareLib
{
    public class IO
    {
        // Creates a filestream
        public static FileStream GetFileStream(string fileLocation)
        {
            FileStream fileStream;           
            try
            {
                var file = new FileInfo(fileLocation);
                fileStream = file.Open(FileMode.Open);
            }
            catch
            {
                return null;                    
            }            

            return fileStream;
        }

        public static bool CompareTheResult(string websiteHash, string fileHash)
        {
            if (websiteHash == fileHash)
            {
                return true;
            }

            return false;
        }
    }
}
