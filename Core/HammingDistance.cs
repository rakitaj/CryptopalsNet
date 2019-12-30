using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CryptopalsNet.Core
{
    public class HammingDistance
    {
        public ByteArray ByteArray { get; }
        public HammingDistance(ByteArray byteArray)
        {
            this.ByteArray = byteArray;
        }

        public int Against(ByteArray other)
        {
            int count = 0;
            var bitArray1 = new BitArray(this.ByteArray.Bytes.ToArray());
            var bitArray2 = new BitArray(other.Bytes.ToArray());
            var difference = bitArray1.Xor(bitArray2);
            foreach(var bit in difference)
            {
                count += (bool)bit == true ? 1 : 0;
            }
            return count;
        }
    }
}
