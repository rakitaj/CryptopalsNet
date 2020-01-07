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
            Assert.Multiple(() => {
                Assert.That(1, Is.EqualTo(characterCount['H']));
                Assert.That(1, Is.EqualTo(characterCount['!']));
                Assert.That(1, Is.EqualTo(characterCount[' ']));
                Assert.That(2, Is.EqualTo(characterCount['o']));
            });
        }
    }
}
