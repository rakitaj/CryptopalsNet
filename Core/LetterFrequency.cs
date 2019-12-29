using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CryptopalsNet.Core.Extensions;

namespace CryptopalsNet.Core
{
    public class LetterFrequency
    {
        public string OriginalText { get; }
        public Dictionary<char, int> CharacterCounts { get; }

        public Dictionary<char, double> LetterFrequencyDict { get; }

        public double DifferenceFromEnglish { get; private set; }

        public LetterFrequency(string input)
        {
            this.OriginalText = input;
            this.CharacterCounts = input.ToCharacterCount();
            int total = this.CharacterCounts.Values.Sum();
            var letterFrequency = new Dictionary<char, double>();
            foreach(var letterKvp in CryptoConstants.LetterFrequency)
            {
                int count = this.CharacterCounts.ContainsKey(letterKvp.Key) ? this.CharacterCounts[letterKvp.Key] : 0;
                letterFrequency[letterKvp.Key] =  (double)count / total;
            }
            this.LetterFrequencyDict = letterFrequency;
        }

        public void CalculateDifferenceFromEnglish()
        {
            double difference = 0;
            foreach(var frequencyKvp in this.LetterFrequencyDict)
            {
                difference += (frequencyKvp.Value - CryptoConstants.LetterFrequency[frequencyKvp.Key]);
            }
            this.DifferenceFromEnglish = difference;
        }


    }
}
