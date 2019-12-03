using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3CrossedWires
{
    public class CrossedWiresCalculator
    {
        private readonly Dictionary<Point, WireStep> _circuit = new Dictionary<Point, WireStep>();
        private readonly List<Wire> _wires = new List<Wire>();

        public CrossedWiresCalculator(string commands)
        {
            CreateCircuit(commands);
            CreateWires(commands);
        }

        private void CreateCircuit(string commands)
        {
            foreach (var wireCommands in commands.Split(Environment.NewLine))
            {
                AddToCircuit(WirePointCreator.GetWireStepPoints(wireCommands));
            }
        }

        private void CreateWires(string commands)
        {
            foreach (var wireCommands in commands.Split(Environment.NewLine))
            {
                _wires.Add(new Wire(WirePointCreator.GetWireStepPoints(wireCommands)));
            }
        }

        private void AddToCircuit(IEnumerable<WireStepPoint> wirePoints)
        {
            foreach (var wirePoint in wirePoints)
            {
                if (_circuit.ContainsKey(wirePoint.Point))
                {
                    var existingWire = _circuit[wirePoint.Point];
                    existingWire.IsHorizontal |= wirePoint.WireStep.IsHorizontal;
                    existingWire.IsVertical |= wirePoint.WireStep.IsVertical;
                }
                else
                {
                    _circuit.Add(wirePoint.Point, wirePoint.WireStep);
                }
            }
        }

        public int CalculateDistance() =>
            ManhattanDistance.ToOrigin(
                _circuit
                    .Where(w => w.Value.IsCrossedWire)
                    .Select(w => w.Key)
                    .WithMinimum(ManhattanDistance.ToOrigin));

        public int CalculateSignalDelay() =>
            LengthTo(_circuit
                .Where(w => w.Value.IsCrossedWire)
                .Select(wp => wp.Key)
                .WithMinimum(LengthTo));

        private int LengthTo(Point point) => _wires.Sum(w => w.LengthTo(point));
    }
}