using System;
using System.Collections.Generic;
using System.Text;
using CryptopalsNet.Core.Extensions;
using NUnit.Framework;

namespace CoreTests
{
    public class IListExtensionTests
    {
        [Test]
        public void ToChunks_TwoEqualChunks()
        {
            var strings = new string[] { "Zero", "One", "Two", "Three" };
            var chunks = strings.ToChunks(2);
            Assert.AreEqual(chunks[0][0], "Zero");
            Assert.AreEqual(chunks[0][1], "One");
            Assert.AreEqual(chunks[1][0], "Two"); 
            Assert.AreEqual(chunks[1][1], "Three");
        }

        [Test]
        public void ToChunks_ThreeChunksWithRemainder()
        {
            var strings = new string[] { "Zero", "One", "Two", "Three", "Four" };
            var chunks = strings.ToChunks(2);
            Assert.AreEqual(chunks[0][0], "Zero");
            Assert.AreEqual(chunks[0][1], "One");
            Assert.AreEqual(chunks[1][0], "Two");
            Assert.AreEqual(chunks[1][1], "Three");
            Assert.AreEqual(chunks[2][0], "Four");
        }

        [Test]
        public void ToChunks_ArrayWithZeroSize()
        {
            var strings = new string[0];
            var chunks = strings.ToChunks(1);
            Assert.AreEqual(new List<string>(), chunks);
        }

        [Test]
        public void ToChunks_ZeroChunkSize_ShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var strings = new string[] { "Something", "AThingOfSome" };
                strings.ToChunks(0);
            });
        }
    }
}
