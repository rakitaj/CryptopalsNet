using System;
using System.Collections.Generic;
using System.Linq;
using CryptopalsNet.Core.Extensions;
using CryptopalsNet.Core.Xor;

namespace CryptopalsNet.Core.ChallengesLogic
{
    public static class Set1
    {
        

        public static LetterFrequency FindEnglishStringSingleCharXor(string[] hexStrings)
        {
            double bestAsciiCharsPercentage = 0;
            LetterFrequency bestLetterFrequency = null;
            foreach(var hex in hexStrings)
            {
                var byteArray = ByteArray.FromHex(hex);
                var decryptedText = XorBreaker.SingleCharXor(byteArray, XorBreaker.BestPercentageAscii);
                if (decryptedText.BackingLetterFreq.PercentageAsciiChars > bestAsciiCharsPercentage)
                {
                    bestAsciiCharsPercentage = decryptedText.BackingLetterFreq.PercentageAsciiChars;
                    bestLetterFrequency = decryptedText.BackingLetterFreq;
                }
            }
            return bestLetterFrequency;
        }

        public static string BreakRepeatingKeyXOR(string base64string)
        {
            byte[] data = Convert.FromBase64String(base64string);
            var byteArray = new ByteArray(data);
            var mostLikelyKeySize = Set1.RepeatingKeyXORKeysize(byteArray);
            var splitBytes = data.ToChunks(mostLikelyKeySize);

            var decryptedTexts = new List<DecryptedText<byte>>();
            foreach(var chunk in splitBytes)
            {
                var chunkBytes = new ByteArray(chunk);
                var decryptedText = XorBreaker.SingleCharXor(chunkBytes, XorBreaker.BestEnglishLetterFreq);
                decryptedTexts.Add(decryptedText);
            }

            string result = String.Empty;
            foreach(var dt in decryptedTexts)
            {
                result = result + dt.PlainText;
            }
            return result;
        }

        public static int RepeatingKeyXORKeysize(ByteArray byteArray)
        {
            var keySizes = new SortedList<int, double>();
            for (int i = 2; i <= 40; i++)
            {
                var first = byteArray.Bytes.Skip(0).Take(i);
                var second = byteArray.Bytes.Skip(i).Take(i);
                var hammingDistance = new HammingDistance(new ByteArray(first)).Against(new ByteArray(second));
                var normalizedDistance = (double)hammingDistance / i;
                keySizes.Add(i, normalizedDistance);
            }
            return keySizes.OrderBy(kvp => kvp.Value).First().Key;
        }

        public static List<List<byte>> TransposeBytes(List<List<byte>> byteChunks)
        {
            var transposedBytets = new List<List<byte>>();
            for(int i = 0; i < byteChunks.Count; i++)
            {
                transposedBytets.Add(Set1.GetByteN(byteChunks, i));
            }
            return transposedBytets;
        }

        public static List<byte> GetByteN(List<List<byte>> byteChunks, int n)
        {
            var result = new List<byte>();
            foreach(var byteChunk in byteChunks)
            {
                result.Add(byteChunk[n]);
            }
            return result;
        }
    }
}
