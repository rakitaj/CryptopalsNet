using System;
using System.Collections.Generic;
using System.Text;
using CryptopalsNet.Core;
using NUnit.Framework;

namespace CoreTests.Challenges
{
    public class Set1Tests
    {
        [Test]
        public void Problem_1_Convert_Hex_To_Base64()
        {
            var input = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
            var expected = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t";
            var byteArray = ByteArray.FromHex(input);
            Assert.AreEqual(expected, byteArray.ToBase64());
        }

        [Test]
        public void Problem_2_Fixed_XOR()
        {
            var byteArray = ByteArray.FromHex("1c0111001f010100061a024b53535009181c");
            var otherByteArray = ByteArray.FromHex("686974207468652062756c6c277320657965");
            Assert.AreEqual("746865206b696420646f6e277420706c6179", byteArray.FixedLengthXOR(otherByteArray).ToHex());
        }
    }
}
