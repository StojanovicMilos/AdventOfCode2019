using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3CrossedWires
{
    public class CrossedWiresDistanceCalculator
    {
        private readonly Dictionary<Point, Wire> _circuit = new Dictionary<Point, Wire>();
        
        public CrossedWiresDistanceCalculator(string commands)
        {
            foreach (var wireCommands in commands.Split(Environment.NewLine))
            {
                Point lastPoint = Point.Origin;
                foreach (var command in wireCommands.Split(','))
                {
                   lastPoint = AddToCircuit(WirePointCalculator.GetWirePoints(lastPoint, command));
                }
            }
        }

        private Point AddToCircuit(IEnumerable<WirePoint> wirePoints)
        {
            Point lastPoint = null;
            foreach (var wirePoint in wirePoints)
            {
                if (_circuit.ContainsKey(wirePoint.Point))
                {
                    var existingWire = _circuit[wirePoint.Point];
                    existingWire.IsHorizontal |= wirePoint.Wire.IsHorizontal;
                    existingWire.IsVertical |= wirePoint.Wire.IsVertical;
                }
                else
                {
                    _circuit.Add(wirePoint.Point, wirePoint.Wire);
                }

                lastPoint = wirePoint.Point;
            }

            return lastPoint;
        }

        public int CalculateDistance() =>
            ManhattanDistance.ToOrigin(
                _circuit
                    .Where(w => w.Value.IsCrossedWire)
                    .Select(w => w.Key)
                    .WithMinimum(ManhattanDistance.ToOrigin));

    }
}
