using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptopalsNet.Core
{
    public class ByteArray
    {
        public List<byte> Bytes { get; }

        public ByteArray(IEnumerable<byte> bytes)
        {
            this.Bytes = bytes.ToList();
        }

        public override bool Equals(object? obj)
        {
            if (obj is ByteArray other)
            {
                return this.Bytes.SequenceEqual(other.Bytes);
            }
            return false;
        }

        public override int GetHashCode()
        {
            int result = 1;
            foreach (var b in this.Bytes)
            {
                result *= b;
            }
            return result;
        }

        public string ToBase64()
        {
            return Convert.ToBase64String(this.Bytes.ToArray());
        }

        public string ToHex()
        {
            string result = string.Empty;
            foreach(var b in this.Bytes)
            {
                result += b.ToString("x2");
            }
            return result;
        }

        public static ByteArray FromHex(string hex)
        {
            var bytes = new List<byte>();
            for (int i = 0; i < hex.Length; i = i + 2)
            {
                var substring = hex.Substring(i, 2);
                bytes.Add(Convert.ToByte(substring, 16));
            }
            return new ByteArray(bytes);
        }

        public HexString XorAgainst(ByteArray other)
        {
            var result = new List<byte>();
            for(int i = 0; i < this.Bytes.Count; i++)
            {
                int xorByte = this.Bytes[i] ^ other.Bytes[i];
                result.Add(Convert.ToByte(xorByte));
            }
            var xorByteArray = new ByteArray(result);
            return new HexString(xorByteArray.ToHex());
        }
    }
}
