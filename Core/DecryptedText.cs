using System;
using System.Collections.Generic;
using System.Text;

namespace CryptopalsNet.Core
{
    public class DecryptedText<T>
    {
        public string PlainText { get; set; }

        public T DecryptionKey { get; set; }

        public LetterFrequency BackingLetterFreq { get; set; }

        public DecryptedText(string plainText, T decryptionKey, LetterFrequency backingLetterFrequency = null)
        {
            this.PlainText = plainText;
            this.DecryptionKey = decryptionKey;
            this.BackingLetterFreq = backingLetterFrequency;
        }
    }
}
