namespace Day3CrossedWires
{
    public class Wire
    {
        public bool IsHorizontal { get; set; }
        public bool IsVertical { get; set; }

        public bool IsCrossedWire => IsHorizontal && IsVertical;

        public static Wire HorizontalWire() => new Wire(isHorizontal: true, isVertical: false);

        public static Wire VerticalWire() => new Wire(isHorizontal: false, isVertical: true);

        private Wire(bool isHorizontal, bool isVertical)
        {
            IsHorizontal = isHorizontal;
            IsVertical = isVertical;
        }
    }
}