using System.Collections.Generic;
using System.Linq;
using System.Text;
using Day3CrossedWires;

namespace Day8SpaceImageFormat
{
    public class ImageWithLayers
    {
        private readonly List<Layer> _layers;
        private readonly int _width;
        private readonly int _height;

        public ImageWithLayers(string input, int width, int height)
        {
            _width = width;
            _height = height;
            _layers = new List<Layer>();
            int layerSize = width * height;
            foreach (var layerInput in input.Split(layerSize))
            {
                _layers.Add(new Layer(layerInput, width, height));
            }
        }

        public int CheckCorruption()
        {
            Layer layer = _layers.WithMinimum(l => l.GetNumberOf(0));
            return layer.GetNumberOf(1) * layer.GetNumberOf(2);
        }

        private const int Transparent = 2;

        public string GetFinalImage()
        {
            StringBuilder finalImage = new StringBuilder();

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    finalImage.Append(_layers.First(l => l.GetPixelAt(i, j) != Transparent).GetPixelAt(i, j));
                }
            }

            return finalImage.ToString();
        }
    }
}