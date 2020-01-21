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

        // public Dictionary<char, double> LetterFrequencyDict { get; }

        public double DifferenceFromEnglish { get; private set; }

        public double PercentageAsciiChars { get; private set; }

        public LetterFrequency(string text)
        {
            this.OriginalText = text;
            this.CharacterCounts = text.ToCharacterCount();
            //int total = this.CharacterCounts.Values.Sum();
            //var letterFrequency = new Dictionary<char, double>();
            //foreach(var letterKvp in CryptoConstants.LetterFrequency)
            //{
            //    int count = this.CharacterCounts.ContainsKey(letterKvp.Key) ? this.CharacterCounts[letterKvp.Key] : 0;
            //    letterFrequency[letterKvp.Key] =  (double)count / total;
            //}
            //this.LetterFrequencyDict = letterFrequency;
        }

        /// <summary>
        /// Calculates the percentage of characters in this text that are ASCII characters. Higher is typically better.
        /// </summary>
        public void CalculatePercentageAsciiChars()
        {
            int nonAsciiChars = 0;
            foreach(var letter in this.OriginalText)
            {
                if(!CryptoConstants.AsciiChars.Contains(letter))
                {
                    nonAsciiChars += 1;
                }
            }
            this.PercentageAsciiChars = 1 - ((double)nonAsciiChars / this.OriginalText.Length);
        }

        /// <summary>
        /// Calculates the "difference" of this text's character distribution from the average English character distribution.
        /// Lower is typically better.
        /// </summary>
        public void CalculateDifferenceFromEnglish()
        {
            double difference = 0;
            var charPercentages = new Dictionary<char, double>();
            foreach(var charCountKvp in this.CharacterCounts)
            {
                charPercentages[charCountKvp.Key] = (double)charCountKvp.Value / this.OriginalText.Length;
            }

            foreach(var charPercentageKvp in charPercentages)
            {
                if (CryptoConstants.AsciiChars.Contains(charPercentageKvp.Key))
                {
                    if (CryptoConstants.LetterFrequency.ContainsKey(charPercentageKvp.Key))
                    {
                        difference += Math.Abs(charPercentageKvp.Value - CryptoConstants.LetterFrequency[charPercentageKvp.Key]);
                    }
                }
                else
                {
                    difference += charPercentageKvp.Value;
                }
                
            }
            this.DifferenceFromEnglish = difference;
        }


    }
}
