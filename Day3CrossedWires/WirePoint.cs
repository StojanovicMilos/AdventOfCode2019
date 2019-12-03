namespace Day3CrossedWires
{
    public class WirePoint
    {
        public Wire Wire { get; }
        public Point Point { get; }

        public WirePoint(Wire wire, Point point)
        {
            Wire = wire;
            Point = point;
        }
    }
}