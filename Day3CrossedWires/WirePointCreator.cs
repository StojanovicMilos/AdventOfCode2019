using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3CrossedWires
{
    public static class WirePointCreator
    {
        private static readonly Dictionary<char, Func<Point, WireStepPoint>> DirectionWireMapper = new Dictionary<char, Func<Point, WireStepPoint>>
        {
            {'U', point => new WireStepPoint(WireStep.VerticalWire(), new Point(point.X, point.Y + 1))},
            {'D', point => new WireStepPoint(WireStep.VerticalWire(), new Point(point.X, point.Y - 1))},
            {'L', point => new WireStepPoint(WireStep.HorizontalWire(), new Point(point.X - 1, point.Y))},
            {'R', point => new WireStepPoint(WireStep.HorizontalWire(), new Point(point.X + 1, point.Y))}
        };

        public static IEnumerable<WireStepPoint> GetWireStepPoints(string wireCommands)
        {
            var wireStepPoints = new List<WireStepPoint>();
            
            wireCommands.Split(',')
                .Aggregate(Point.Origin, (current, command) =>
                {
                    wireStepPoints.AddRange(GetWireStepPoints(current, command));
                    return wireStepPoints.Last().Point;
                });

            return wireStepPoints;
        }

        private static IEnumerable<WireStepPoint> GetWireStepPoints(Point startingPoint, string command)
        {
            char direction = command[0];
            var wireMapper = DirectionWireMapper[direction];
            int wireLength = Convert.ToInt32(command.Substring(1));

            WireStepPoint wirePoint = wireMapper(startingPoint);
            for (int i = 0; i < wireLength; i++)
            {
                yield return wirePoint;
                wirePoint = wireMapper(wirePoint.Point);
            }
        }
    }
}