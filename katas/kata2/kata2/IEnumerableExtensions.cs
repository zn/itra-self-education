using System;
using System.Linq;
using System.Collections.Generic;

namespace kata2
{
    public static class IEnumerableExtensions
    {
        public static int Pivot<T> (this IEnumerable<T> slice)
        {
            return slice.Count() / 2;
        }
    }
}