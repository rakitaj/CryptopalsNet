using System;
using System.Collections.Generic;
using System.Text;

namespace CryptopalsNet.Core.Extensions
{
    public static class StringExtensions
    {
        public static Dictionary<char, int> ToCharacterCount(this string value)
        {
            if (value == null) { throw new ArgumentNullException(nameof(value)); }
            var result = new Dictionary<char, int>();
            foreach(var c in value)
            {
                if (result.ContainsKey(c))
                {
                    result[c] += 1;
                }
                else
                {
                    result[c] = 1;
                }
            }
            return result;
        }
    }
}
