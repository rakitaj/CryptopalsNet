using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptopalsNet.Core
{
    public class HexString
    {
        public string Value { get; }

        public HexString(string hex)
        {
            if (HexString.IsValid(hex))
            {
                this.Value = hex;
            }
            else
            {
                throw new ArgumentException($"Input string {hex} is not valid hex");
            }
        }

        public static bool IsValid(string hex)
        {
            return hex != null && hex.Length % 2 == 0 && hex.All(c => HexString.IsCharacterHex(c));
        }

        public static bool IsCharacterHex(char c)
        {
            return ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'));
        }
    }
}
