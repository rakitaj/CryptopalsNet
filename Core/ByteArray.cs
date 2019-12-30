using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public override string ToString()
        {
            return Encoding.ASCII.GetString(this.Bytes.ToArray());
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

        public static ByteArray FromAscii(string ascii)
        {
            var bytes = Encoding.ASCII.GetBytes(ascii);
            return new ByteArray(bytes);
        }

        public ByteArray FixedLengthXOR(ByteArray other)
        {
            if(other == null || this.Bytes.Count != other.Bytes.Count)
            {
                throw new ArgumentException($"ByteArray other is either null or does not have the same count.");
            }
            var result = new List<byte>();
            for(int i = 0; i < this.Bytes.Count; i++)
            {
                int xorByte = this.Bytes[i] ^ other.Bytes[i];
                result.Add(Convert.ToByte(xorByte));
            }
            return new ByteArray(result);
        }

        public ByteArray SingleCharacterXOR(int xor)
        {
            var result = new List<byte>();
            foreach (var b in this.Bytes)
            {
                int xorByte = b ^ xor;
                result.Add(Convert.ToByte(xorByte));
            }
            return new ByteArray(result);
        }

        public ByteArray SingleCharacterXOR(char xor)
        {
            return this.SingleCharacterXOR((int)xor);
        }

        public ByteArray RepeatingKeyXOR(string xorKey)
        {
            int bytesCount = 0;
            int keyCount = 0;
            var bytes = new List<byte>();
            while(bytesCount < this.Bytes.Count)
            {
                var b = this.Bytes[bytesCount] ^ xorKey[keyCount];
                bytesCount += 1;
                keyCount = (keyCount + 1) % xorKey.Length;
                bytes.Add(Convert.ToByte(b));
            }
            return new ByteArray(bytes);
        }
    }
}
