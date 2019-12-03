namespace Day3CrossedWires
{
    public class WireStep
    {
        public bool IsHorizontal { get; set; }
        public bool IsVertical { get; set; }

        public bool IsCrossedWire => IsHorizontal && IsVertical;

        public static WireStep HorizontalWire() => new WireStep(isHorizontal: true, isVertical: false);

        public static WireStep VerticalWire() => new WireStep(isHorizontal: false, isVertical: true);

        private WireStep(bool isHorizontal, bool isVertical)
        {
            IsHorizontal = isHorizontal;
            IsVertical = isVertical;
        }
    }
}