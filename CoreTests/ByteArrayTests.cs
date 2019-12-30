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
            Assert.AreEqual(100 * 2 * 10, byteArray.GetHashCode());
        }

        [Test]
        public void ByteArray_GetHashCode_WithOverflow()
        {
            var byteArray = new ByteArray(new byte[] { 255, 255, 255, 255 });
            Assert.AreEqual(-66716671, byteArray.GetHashCode());
        }

        [Test]
        public void ByteArray_Equals()
        {
            var byteArray1 = new ByteArray(new byte[] { 100, 2, 10 });
            var byteArray2 = new ByteArray(new byte[] { 100, 2, 10 });
            Assert.IsTrue(byteArray1.Equals(byteArray2));
        }

        [TestCase("00", new byte[] { 0 })]
        [TestCase("FF", new byte[] { 255 })]
        [TestCase("FF00FF", new byte[] { 255, 0, 255 })]
        [TestCase("FF0809", new byte[] { 255, 8, 9 })]
        public void HexString_To_ByteArray(string hex, byte[] bytes)
        {
            var expected = new ByteArray(bytes);
            var actual = ByteArray.FromHex(hex);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("$Nil !", new byte[] { 36, 78, 105, 108, 32, 33})]
        public void ByteArray_ToString(string expected, byte[] bytes)
        {
            var byteArray = new ByteArray(bytes);
            Assert.AreEqual(expected, byteArray.ToString());
        }

        [TestCase("ICE", "Hello, world!", new byte[] { 1, 38, 41, 37, 44, 105, 105, 52, 42, 59, 47, 33, 104 })]
        public void ByteArray_RepeatingKeyXOR(string xorKey, string target, byte[] expected)
        {
            var byteArray = ByteArray.FromAscii(target);
            var actual = byteArray.RepeatingKeyXOR(xorKey);
            Assert.AreEqual(expected, actual.Bytes);
        }
    }
}
