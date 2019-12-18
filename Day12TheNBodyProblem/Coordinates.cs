using System;

namespace Day12TheNBodyProblem
{
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Coordinates(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int Energy => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);

        public string GetState() => $"<x={X.ToString().PadLeft(3)}, y={Y.ToString().PadLeft(3)}, z={Z.ToString().PadLeft(3)}>";
    }
}