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
            var decryptedTexts = new List<DecryptedText<byte>>();
            for (int byteValue = 0; byteValue < 256; byteValue++)
            {
                var xordString = byteArray.SingleCharacterXOR(byteValue).ToString();
                var decryptedText = new DecryptedText<byte>(xordString, Convert.ToByte(byteValue));
                decryptedText.CalculatePercentageAsciiChars();
                decryptedText.CalculateDifferenceFromEnglish();
                decryptedTexts.Add(decryptedText);
            }
            return orderingMethod.Invoke(decryptedTexts);
        }

        public static DecryptedText<byte> BestPercentageAscii(List<DecryptedText<byte>> decryptedTexts)
        {
            return decryptedTexts.OrderBy(dt => dt.PercentageAsciiChars).Last();
        }

        public static DecryptedText<byte> BestEnglishLetterFreq(List<DecryptedText<byte>> decryptedTexts)
        {
            return decryptedTexts.OrderBy(dt => dt.DifferenceFromEnglish).First();
        }
    }
}
