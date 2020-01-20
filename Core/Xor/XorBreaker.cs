using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptopalsNet.Core.Xor
{
    public class XorBreaker
    {
        public delegate DecryptedText<byte> OrderingMethod(List<DecryptedText<byte>> decryptedTexts);

        public static DecryptedText<byte> SingleCharXor(ByteArray byteArray, OrderingMethod orderingMethod)
        {
            if(byteArray == null)
            {
                throw new ArgumentNullException(nameof(byteArray));
            }

            var decryptedTexts = new List<DecryptedText<byte>>();
            for (int byteValue = 0; byteValue < 256; byteValue++)
            {
                var xordString = byteArray.SingleCharacterXOR(byteValue).ToString();
                var letterFrequency = new LetterFrequency(xordString);
                letterFrequency.CalculatePercentageAsciiChars();
                letterFrequency.CalculateDifferenceFromEnglish();
                decryptedTexts.Add(new DecryptedText<byte>(letterFrequency.OriginalText, Convert.ToByte(byteValue), letterFrequency));
            }
            return orderingMethod.Invoke(decryptedTexts);
        }

        public static DecryptedText<byte> BestPercentageAscii(List<DecryptedText<byte>> decryptedTexts)
        {
            return decryptedTexts.OrderBy(dt => dt.BackingLetterFreq.PercentageAsciiChars).Last();
        }

        public static DecryptedText<byte> BestEnglishLetterFreq(List<DecryptedText<byte>> decryptedTexts)
        {
            return decryptedTexts.OrderBy(dt => dt.BackingLetterFreq.DifferenceFromEnglish).First();
        }
    }
}
