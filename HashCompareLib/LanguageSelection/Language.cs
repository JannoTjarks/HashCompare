using System;

namespace HashCompareLib.LanguageSelection
{
    // author: Janno Tjarks (janno.tjarks@hotmail.de)
    // version: 1.0
    // date: 2018-04-14
    /// <summary>
    /// This class has all strings for the output in the console.
    /// </summary>
    public class Language
    {
        #region private variables
        private string unrecognizedOption = String.Empty;
        private string greeting = String.Empty;
        private string giveHash = String.Empty;
        private string givePath = String.Empty;
        private string pathError = String.Empty;
        private string giveHashMethod = String.Empty;
        private string hashError = String.Empty;
        private string websitheHash = String.Empty;
        private string fileHash = String.Empty;
        private string resultBegin = String.Empty;
        private string resultEndPositiv = String.Empty;
        private string resultEndNegativ = String.Empty;
        private string close = String.Empty;

        #endregion

        #region Getter and Setter
        public string UnrecognizedOption { get => this.unrecognizedOption; set => this.unrecognizedOption = value; }
        public string Greeting { get => greeting; set => greeting = value; }
        public string GiveHash { get => giveHash; set => giveHash = value; }
        public string GivePath { get => givePath; set => givePath = value; }
        public string PathError { get => pathError; set => pathError = value; }
        public string GiveHashMethod { get => giveHashMethod; set => giveHashMethod = value; }
        public string HashError { get => hashError; set => hashError = value; }
        public string WebsitheHash { get => websitheHash; set => websitheHash = value; }
        public string FileHash { get => fileHash; set => fileHash = value; }
        public string ResultBegin { get => resultBegin; set => resultBegin = value; }
        public string ResultEndPositiv { get => resultEndPositiv; set => resultEndPositiv = value; }
        public string ResultEndNegativ { get => resultEndNegativ; set => resultEndNegativ = value; }
        public string Close { get => close; set => close = value; }        

        #endregion
    }
}