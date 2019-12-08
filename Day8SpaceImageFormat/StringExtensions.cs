using System.Collections.Generic;
using System.Linq;

namespace Day8SpaceImageFormat
{
    public static class StringExtensions
    {
        public static IEnumerable<string> Split(this string str, int chunkSize) =>
            Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
    }
}