using System.Collections.Generic;
using System.Linq;

namespace Day3CrossedWires
{
    public class Wire
    {
        private readonly IEnumerable<WireStepPoint> _wireStepPoints;

        public Wire(IEnumerable<WireStepPoint> wireStepPoints)
        {
            _wireStepPoints = wireStepPoints;
        }

        public int LengthTo(Point point) => _wireStepPoints.TakeWhile(w => w.Point != point).Count() + 1;
    }
}
