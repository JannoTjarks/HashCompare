using System;
using System.Collections.Generic;
using System.Text;

namespace HashCompare.Language
{
    public class LanguageSelect
    {
        private string greeting = String.Empty;
        private string giveHash = String.Empty;
        private string givePath = String.Empty;
        private string pathError = String.Empty;
        private string giveHashMethod = String.Empty;
        private string hashError = String.Empty;
        private string resultBegin = String.Empty;
        private string resultEndPositiv = String.Empty;
        private string resultEndNegativ = String.Empty;
        private string close = String.Empty;

        public string Greeting { get => greeting; set => greeting = value; }
        public string GiveHash { get => giveHash; set => giveHash = value; }
        public string GivePath { get => givePath; set => givePath = value; }
        public string PathError { get => pathError; set => pathError = value; }
        public string GiveHashMethod { get => giveHashMethod; set => giveHashMethod = value; }
        public string HashError { get => hashError; set => hashError = value; }
        public string ResultBegin { get => resultBegin; set => resultBegin = value; }
        public string ResultEndPositiv { get => resultEndPositiv; set => resultEndPositiv = value; }
        public string ResultEndNegativ { get => resultEndNegativ; set => resultEndNegativ = value; }
        public string Close { get => close; set => close = value; }
    }
}