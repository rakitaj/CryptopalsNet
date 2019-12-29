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
    }
}
