using System;
using System.Collections.Generic;
using System.Text;
using CryptopalsNet.Core.Extensions;
using NUnit.Framework;

namespace CoreTests
{
    public class StringExtensionTests
    {
        [Test]
        public void ToCharacterCount_HelloWorld()
        {
            var characterCount = "Hello, world!".ToCharacterCount();
            Assert.AreEqual(1, characterCount['H']);
            Assert.AreEqual(1, characterCount['!']);
            Assert.AreEqual(1, characterCount[' ']);
            Assert.AreEqual(2, characterCount['o']);
        }
    }
}
