using System.Linq;

namespace Day3CrossedWires.Tests
{
    public static class StringExtensions
    {
        public static string[] SplitWithoutEmptyStrings(this string initial, string separator) => initial.Split(separator).Where(i => !string.IsNullOrEmpty(i)).ToArray();
    }
}
