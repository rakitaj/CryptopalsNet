using System;
using System.Collections.Generic;
using System.Text;

namespace CryptopalsNet.Core
{
    public class DecryptedText<T> : LetterFrequency
    {
        public string PlainText { get; set; }

        public T DecryptionKey { get; set; }

        public DecryptedText(string plainText, T decryptionKey) : base(plainText)
        {
            this.PlainText = plainText;
            this.DecryptionKey = decryptionKey;
        }
    }
}
