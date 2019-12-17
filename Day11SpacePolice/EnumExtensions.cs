using System;

namespace Day11SpacePolice
{
    public static class EnumExtensions
    {
        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException($"Argument {typeof(T).FullName} is not an Enum");

            T[] array = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf(array, src) + 1;
            return array.Length == j ? array[0] : array[j];
        }

        public static T Previous<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException($"Argument {typeof(T).FullName} is not an Enum");

            T[] array = (T[]) Enum.GetValues(src.GetType());
            int j = Array.IndexOf(array, src) - 1;
            return j < 0 ? array[array.Length + j] : array[j];
        }
    }
}