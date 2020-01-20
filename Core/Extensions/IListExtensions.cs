using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CryptopalsNet.Core.Extensions
{
    public static class IListExtensions
    {
        public static List<List<T>> ToChunks<T>(this IList<T> list, int chunkSize)
        {
            if (chunkSize <= 0)
            {
                throw new InvalidOperationException("Zero and negative numbers are not valid chunk sizes.");
            }
            var result = new List<List<T>>();
            int i = 0;
            while(i < list.Count)
            {
                var chunk = new List<T>();
                for(int j = 0; j < chunkSize && i < list.Count; j++, i++)
                {
                    chunk.Add(list[i]);
                }
                result.Add(chunk);
            }
            return result;
        }
    }
}
