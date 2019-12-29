using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CryptopalsNet.Core.Extensions;

namespace CryptopalsNet.Core.ChallengesLogic
{
    public class Set1
    {
        public static string SingleCharXorDecoder(string inputHex)
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
            return letterFreqs.OrderBy(tpl => Math.Abs(tpl.Item1.DifferenceFromEnglish)).First().Item1.OriginalText;
        }
    }
}
