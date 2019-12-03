using System;
using System.Collections.Generic;

namespace Day3CrossedWires
{
    public static class WirePointCalculator
    {
        private static readonly Dictionary<char, Func<Point, WirePoint>> DirectionWireMapper = new Dictionary<char, Func<Point, WirePoint>>
        {
            {'U', point => new WirePoint(Wire.VerticalWire(), new Point(point.X, point.Y + 1))},
            {'D', point => new WirePoint(Wire.VerticalWire(), new Point(point.X, point.Y - 1))},
            {'L', point => new WirePoint(Wire.HorizontalWire(), new Point(point.X - 1, point.Y))},
            {'R', point => new WirePoint(Wire.HorizontalWire(), new Point(point.X + 1, point.Y))}
        };

        public static IEnumerable<WirePoint> GetWirePoints(Point startingPoint, string command)
        {
            char direction = command[0];
            var wireMapper = DirectionWireMapper[direction];
            int wireLength = Convert.ToInt32(command.Substring(1));

            WirePoint wirePoint = wireMapper(startingPoint);
            for (int i = 0; i < wireLength; i++)
            {
                yield return wirePoint;
                wirePoint = wireMapper(wirePoint.Point);
            }
        }
    }
}