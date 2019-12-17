using Day11SpacePolice.Day11SpacePolice;

namespace Day11SpacePolice
{
    public class Panel
    {
        public int X { get; }
        public int Y { get;}
        public Color Color { get; }

        public Panel(int x, int y, Color color = Color.Black)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
}