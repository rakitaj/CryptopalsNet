using CryptopalsNet.Core;
using NUnit.Framework;

namespace CoreTests
{
    public class ByteArrayTests
    {
        [Test]
        public void ByteArray_GetHashCode()
        {
            var byteArray = new ByteArray(new byte[] { 100, 2, 10 });
            Assert.That(byteArray.GetHashCode(), Is.EqualTo(100 * 2 * 10));
        }

        [Test]
        public void ByteArray_GetHashCode_WithOverflow()
        {
            var byteArray = new ByteArray(new byte[] { 255, 255, 255, 255 });
            Assert.That(byteArray.GetHashCode(), Is.EqualTo(-66716671));
        }

        [Test]
        public void ByteArray_Equals()
        {
            var byteArray1 = new ByteArray(new byte[] { 100, 2, 10 });
            var byteArray2 = new ByteArray(new byte[] { 100, 2, 10 });
            Assert.That(byteArray1.Equals(byteArray2), Is.True);
        }

        [TestCase("00", new byte[] { 0 })]
        [TestCase("FF", new byte[] { 255 })]
        [TestCase("FF00FF", new byte[] { 255, 0, 255 })]
        [TestCase("FF0809", new byte[] { 255, 8, 9 })]
        public void HexString_To_ByteArray(string hex, byte[] bytes)
        {
            var expected = new ByteArray(bytes);
            var actual = ByteArray.FromHex(hex);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [TestCase("$Nil !", new byte[] { 36, 78, 105, 108, 32, 33})]
        public void ByteArray_ToString(string expected, byte[] bytes)
        {
            var byteArray = new ByteArray(bytes);
            Assert.That(expected, Is.EqualTo(byteArray.ToString()));
        }

        [TestCase("ICE", "Hello, world!", new byte[] { 1, 38, 41, 37, 44, 105, 105, 52, 42, 59, 47, 33, 104 })]
        public void ByteArray_RepeatingKeyXOR(string xorKey, string target, byte[] expected)
        {
            var byteArray = ByteArray.FromAscii(target);
            var actual = byteArray.RepeatingKeyXOR(ByteArray.FromAscii("ICE"));
            Assert.That(expected, Is.EqualTo(actual.Bytes));
        }
    }
}
