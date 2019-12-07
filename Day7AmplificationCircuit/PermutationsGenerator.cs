using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7AmplificationCircuit
{
    public static class PermutationsGenerator
    {
        public static int[][] Permutate(int[] source)
        {
            string stringSource = string.Join("", source.Select(number => number.ToString()));
            var permutations = Permutate(stringSource);
            return permutations.Select(ConvertToIntArray).ToArray();
        }

        private static int[] ConvertToIntArray(string s) => s.Select(c => int.Parse(c.ToString())).ToArray();

        private static IEnumerable<string> Permutate(string source)
        {
            if (source.Length == 1) return new List<string> { source };

            var permutations = from c in source
                from p in Permutate(new String(source.Where(x => x != c).ToArray()))
                select c + p;

            return permutations;
        }
    }
}