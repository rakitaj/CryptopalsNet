using System;
using System.Collections.Generic;
using System.Text;
using CryptopalsNet.Core;
using NUnit.Framework;

namespace CoreTests
{
    public class HammingDistanceTests
    {
        [Test]
        public void HammingDistance_Against_CryptopalsExample()
        {
            var first = ByteArray.FromAscii("this is a test");
            var second = ByteArray.FromAscii("wokka wokka!!!");
            var hammingDistance = new HammingDistance(first);
            Assert.That(hammingDistance.Against(second), Is.EqualTo(37));
        }

        [TestCase("fuse", "fuel", 5)]
        public void HammingDistance_TestCase(string text1, string text2, int hammingDistance)
        {
            var first = ByteArray.FromAscii(text1);
            var second = ByteArray.FromAscii(text2);
            Assert.That(new HammingDistance(first).Against(second), Is.EqualTo(hammingDistance));
        }
    }
}
