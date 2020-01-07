using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using CryptopalsNet.Core;

namespace CoreTests
{
    public class HexStringTests
    {
        [TestCase('a', true)]
        [TestCase('F', true)]
        [TestCase('Q', false)]
        [TestCase('0', true)]
        [TestCase('9', true)]
        [TestCase('4', true)]
        public void HexString_IsCharacterHex(char c, bool expected)
        {
            Assert.That(expected, Is.EqualTo(HexString.IsCharacterHex(c)));
        }

        [TestCase("Hello world!", false)]
        [TestCase("1c0111001f010100061a024b53535009181c", true)]
        [TestCase("1c011g", false)]
        [TestCase("1c011ff", false)]
        public void HexString_IsValid(string hex, bool expected)
        {
            Assert.That(expected, Is.EqualTo(HexString.IsValid(hex)));
        }
    }
}
