namespace Day3CrossedWires
{
    public class WireStepPoint
    {
        public WireStep WireStep { get; }
        public Point Point { get; }

        public WireStepPoint(WireStep wireStep, Point point)
        {
            WireStep = wireStep;
            Point = point;
        }
    }
}