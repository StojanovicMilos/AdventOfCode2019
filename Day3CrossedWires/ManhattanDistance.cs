using System;

namespace Day3CrossedWires
{
    public static class ManhattanDistance
    {
        public static int Between(Point point1, Point point2) => Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y);

        public static int ToOrigin(Point point) => Between(point, Point.Origin);
    }
}