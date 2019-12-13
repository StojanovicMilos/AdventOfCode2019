namespace Day10MonitoringStation
{
    public class Asteroid
    {
        public int X { get; }
        public int Y { get; }

        public Asteroid(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"{Y},{X}";
    }
}