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
            Assert.Multiple(() => {
                Assert.That(chunks[0][0], Is.EqualTo("Zero"));
                Assert.That(chunks[0][1], Is.EqualTo("One"));
                Assert.That(chunks[1][0], Is.EqualTo("Two"));
                Assert.That(chunks[1][1], Is.EqualTo("Three"));
            });
        }

        [Test]
        public void ToChunks_ThreeChunksWithRemainder()
        {
            var strings = new string[] { "Zero", "One", "Two", "Three", "Four" };
            var chunks = strings.ToChunks(2);
            Assert.Multiple(() =>
            {
                Assert.That(chunks[0][0], Is.EqualTo("Zero"));
                Assert.That(chunks[0][1], Is.EqualTo("One"));
                Assert.That(chunks[1][0], Is.EqualTo("Two"));
                Assert.That(chunks[1][1], Is.EqualTo("Three"));
                Assert.That(chunks[2][0], Is.EqualTo("Four"));
            });
        }

        [Test]
        public void ToChunks_LargeArraySmallChunkSize()
        {
            var bytes = new byte[1234];
            var chunks = bytes.ToChunks(10);
            Assert.That(chunks.Count, Is.EqualTo(124));
            Assert.That(chunks[0].Count, Is.EqualTo(10));
            Assert.That(chunks[123].Count, Is.EqualTo(4));
        }

        [Test]
        public void ToChunks_ArrayWithZeroSize()
        {
            var strings = new string[0];
            var chunks = strings.ToChunks(1);
            Assert.That(chunks, Is.EqualTo(new List<string>()));
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
