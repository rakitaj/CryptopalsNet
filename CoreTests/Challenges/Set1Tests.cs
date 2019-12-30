using System;
using CryptopalsNet.Core;
using CryptopalsNet.Core.ChallengesLogic;
using NUnit.Framework;

namespace CoreTests.Challenges
{
    public class Set1Tests
    {
        [Test]
        public void Challenge_1_Convert_Hex_To_Base64()
        {
            var input = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
            var expected = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t";
            var byteArray = ByteArray.FromHex(input);
            Assert.AreEqual(expected, byteArray.ToBase64());
        }

        [Test]
        public void Challenge_2_Fixed_XOR()
        {
            var byteArray = ByteArray.FromHex("1c0111001f010100061a024b53535009181c");
            var otherByteArray = ByteArray.FromHex("686974207468652062756c6c277320657965");
            Assert.AreEqual("746865206b696420646f6e277420706c6179", byteArray.FixedLengthXOR(otherByteArray).ToHex());
        }

        [Test]
        public void Challenge_3_SingleByte_XOR_Cipher()
        {
            var hexInput = "1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736";
            var actual = Set1.SingleCharXorDecoder(hexInput);
            Assert.AreEqual("Cooking MC's like a pound of bacon", actual.OriginalText);
        }

        [Test]
        public void Challenge_4_Detect_Single_Character_XOR()
        {
            var input = System.IO.File.ReadAllLines("..\\..\\..\\ChallengesData\\set1-problem3.txt");
            var actual = Set1.FindEnglishStringSingleCharXor(input);
            Assert.AreEqual("Now that the party is jumping\n", actual.OriginalText);
        }
    }
}
