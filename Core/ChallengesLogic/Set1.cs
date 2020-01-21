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
                if (decryptedText.PercentageAsciiChars > bestAsciiCharsPercentage)
                {
                    bestAsciiCharsPercentage = decryptedText.PercentageAsciiChars;
                    bestLetterFrequency = decryptedText;
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

            var transposedBytes = Set1.TransposeBytes(splitBytes, mostLikelyKeySize);

            var decryptedTexts = new List<DecryptedText<byte>>();

            foreach (var transposedChunk in transposedBytes)
            {
                var decryptedText = XorBreaker.SingleCharXor(new ByteArray(transposedChunk), XorBreaker.BestEnglishLetterFreq);
                decryptedTexts.Add(decryptedText);
            }

            List<byte> decryptionKey = decryptedTexts.Select(dt => dt.DecryptionKey).ToList();

            var xorDecrypt = new XorDecrypt(byteArray);
            var resultBytes = xorDecrypt.DecryptWithRepeatingKey(new ByteArray(decryptionKey));

            return resultBytes.ToString();
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

        public static List<List<byte>> TransposeBytes(List<List<byte>> byteChunks, int n)
        {
            var transposedBytets = new List<List<byte>>();
            for(int i = 0; i < n; i++)
            {
                var transposedChunk = byteChunks.Where(bc => bc.Count == n).Select(bc => bc[i]).ToList();
                transposedBytets.Add(transposedChunk);
            }
            return transposedBytets;
        }
    }
}
