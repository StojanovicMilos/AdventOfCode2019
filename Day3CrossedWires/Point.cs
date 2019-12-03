using System;

namespace Day3CrossedWires
{
    public class Point : IEquatable<Point>
    {
        public static readonly Point Origin = new Point(0, 0);

        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj) => Equals(obj as Point);

        public bool Equals(Point other) => X == other?.X && Y == other.Y;

        public static bool operator ==(Point onePoint, Point otherPoint) => onePoint?.Equals(otherPoint) == true;

        public static bool operator !=(Point onePoint, Point otherPoint) => !(onePoint == otherPoint);

        //from https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-overriding-gethashcode/263416#263416
        public override int GetHashCode()
        {
            unchecked
            {
                return (391 + X.GetHashCode()) * 23 + Y.GetHashCode();
            }
        }
    }
}
