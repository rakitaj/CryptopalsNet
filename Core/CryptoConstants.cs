﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CryptopalsNet.Core
{
    public class CryptoConstants
    {
        public Dictionary<char, double> LetterFrequency
        {
            get
            {
                return new Dictionary<char, double> {
                    { 'E', 12.0 },
                    { 'T', 9.10 },
                    { 'A', 8.12 },
                    { 'O', 7.68 },
                    { 'I', 7.31 },
                    { 'N', 6.95 },
                    { 'S', 6.28 },
                    { 'R', 6.02 },
                    { 'H', 5.92 },
                    { 'D', 4.32 },
                    { 'L', 3.98 },
                    { 'U', 2.88 },
                    { 'C', 2.71 },
                    { 'M', 2.61 },
                    { 'F', 2.30 },
                    { 'Y', 2.11 },
                    { 'W', 2.09 },
                    { 'G', 2.03 },
                    { 'P', 1.82 },
                    { 'B', 1.49 },
                    { 'V', 1.11 },
                    { 'K', 0.69 },
                    { 'X', 0.17 },
                    { 'Q', 0.11 },
                    { 'J', 0.10 },
                    { 'Z', 0.07 } };
            }
        }
    }
}
