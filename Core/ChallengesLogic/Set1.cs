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
                letterFrequency.CalculateDifferenceFromEnglish();
                letterFreqs.Add(Tuple.Create(letterFrequency, byteValue));
            }
            return letterFreqs.OrderBy(tpl => Math.Abs(tpl.Item1.DifferenceFromEnglish)).First().Item1;
        }

        public static LetterFrequency FindEnglishStringSingleCharXor(string[] hexStrings)
        {
            var lowestDifference = Tuple.Create<double, LetterFrequency>(double.MaxValue, null);
            foreach(var hex in hexStrings)
            {
                var letterFrequency = Set1.SingleCharXorDecoder(hex);
                if (Math.Abs(letterFrequency.DifferenceFromEnglish) < lowestDifference.Item1)
                {
                    lowestDifference = Tuple.Create(Math.Abs(letterFrequency.DifferenceFromEnglish), letterFrequency);
                }
            }
            return lowestDifference.Item2;
        }
    }
}
