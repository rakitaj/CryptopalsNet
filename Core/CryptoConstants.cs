using System;
using System.Collections.Generic;
using System.Text;

namespace CryptopalsNet.Core
{
    public static class CryptoConstants
    {
        public static string AsciiChars => "0123456789 abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ\n";

        public static Dictionary<char, double> LetterFrequency => new Dictionary<char, double> {
                    { 'E', .120 },
                    { 'T', .0910 },
                    { 'A', .0812 },
                    { 'O', .0768 },
                    { 'I', .0731 },
                    { 'N', .0695 },
                    { 'S', .0628 },
                    { 'R', .0602 },
                    { 'H', .0592 },
                    { 'D', .0432 },
                    { 'L', .0398 },
                    { 'U', .0288 },
                    { 'C', .0271 },
                    { 'M', .0261 },
                    { 'F', .0230 },
                    { 'Y', .0211 },
                    { 'W', .0209 },
                    { 'G', .0203 },
                    { 'P', .0182 },
                    { 'B', .0149 },
                    { 'V', .0111 },
                    { 'K', .0069 },
                    { 'X', .0017 },
                    { 'Q', .0011 },
                    { 'J', .0010 },
                    { 'Z', .0007 } };
    }
}
