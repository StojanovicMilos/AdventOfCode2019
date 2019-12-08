using System;
using System.Linq;

namespace Day8SpaceImageFormat
{
    public class Layer
    {
        private readonly int[,] _pixels;
        private readonly int[] _flattenedPixels;

        public Layer(string input, int width, int height)
        {
            if (input.Length != width * height)
                throw new ArgumentException();

            _flattenedPixels = input.Select(c => int.Parse(c.ToString())).ToArray();

            _pixels = new int[width, height];
            for (int i = 0; i < _flattenedPixels.Length; i++)
            {
                _pixels[i / height, i % height] = _flattenedPixels[i];
            }
        }

        public int GetNumberOf(int value) => _flattenedPixels.Count(v => v == value);

        public int GetPixelAt(int width, int height) => _pixels[width, height];
    }
}