using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CryptopalsNet.Core.Extensions;

namespace CryptopalsNet.Core.ChallengesLogic
{
    public static class Set1
    {
        public static LetterFrequency SingleCharXorDecoder(string inputHex)
        {
            var letterFreqs = new List<Tuple<LetterFrequency, int>>();
            foreach(var byteValue in Enumerable.Range(0, 255))
            {
                var byteArray = ByteArray.FromHex(inputHex);
                var xordString = byteArray.SingleCharacterXOR(byteValue).ToString();
                var letterFrequency = new LetterFrequency(xordString);
                letterFrequency.CalculatePercentageAsciiChars();
                letterFreqs.Add(Tuple.Create(letterFrequency, byteValue));
            }
            return letterFreqs.OrderBy(tpl => tpl.Item1.PercentageAsciiChars).Last().Item1;
        }

        public static LetterFrequency FindEnglishStringSingleCharXor(string[] hexStrings)
        {
            var mostAsciiChars = Tuple.Create<double, LetterFrequency>(0, null);
            foreach(var hex in hexStrings)
            {
                var letterFrequency = Set1.SingleCharXorDecoder(hex);
                if (letterFrequency.PercentageAsciiChars > mostAsciiChars.Item1)
                {
                    mostAsciiChars = Tuple.Create(letterFrequency.PercentageAsciiChars, letterFrequency);
                }
            }
            return mostAsciiChars.Item2;
        }
    }
}
