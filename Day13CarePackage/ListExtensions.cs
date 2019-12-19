using System;
using System.Collections.Generic;
using System.Numerics;

namespace Day13CarePackage
{
    public static class ListExtensions
    {
        public static List<List<BigInteger>> SplitList(this List<BigInteger> list, int size)
        {
            var returnList = new List<List<BigInteger>>();

            for (int i = 0; i < list.Count; i += size)
            {
                returnList.Add(list.GetRange(i, Math.Min(size, list.Count - i)));
            }

            return returnList;
        }
    }
}