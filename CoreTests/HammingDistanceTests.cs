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
    }
}
