using System;

namespace Day10MonitoringStation
{
    public class DeltaAngle
    {
        public int X { get; }
        public int Y { get; }

        public DeltaAngle(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double Angle => (360 + 90 - (Math.Atan2(-Y, X) * (180 / Math.PI))) % 360;

        public override string ToString() => $"{X},{Y}";
    }
}