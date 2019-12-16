using System.Collections.Generic;
using System.Linq;

namespace Day10MonitoringStation
{
    public class AngleHelper
    {
        private readonly DeltaAngle[] _angles;
        private int _index;

        public AngleHelper(int biggestXCoordinate, int biggestYCoordinate)
        {
            _index = 0;
            _angles = GenerateAngles(biggestXCoordinate, biggestYCoordinate).OrderBy(a => a.Angle).ToArray();
        }

        private Dictionary<string, DeltaAngle>.ValueCollection GenerateAngles(int biggestXCoordinate, int biggestYCoordinate)
        {
            var angles = GenerateFirstQuadrantAngles(biggestXCoordinate, biggestYCoordinate);
            angles = GenerateOtherQuadrantsAngles(angles);
            return angles.Values;
        }

        private static Dictionary<string, DeltaAngle> GenerateFirstQuadrantAngles(int biggestXCoordinate, int biggestYCoordinate)
        {
            Dictionary<string, DeltaAngle> angles = new Dictionary<string, DeltaAngle>();
            for (int x = 0; x <= biggestXCoordinate; x++)
            {
                for (int y = 0; y <= biggestYCoordinate; y++)
                {
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }

                    int greatestCommonDivisor = MyMath.GreatestCommonDivisor(x, y);
                    var newAngle = new DeltaAngle(x / greatestCommonDivisor, y / greatestCommonDivisor);
                    if (!angles.ContainsKey(newAngle.ToString()))
                    {
                        angles.Add(newAngle.ToString(), newAngle);
                    }
                }
            }

            return angles;
        }

        private Dictionary<string, DeltaAngle> GenerateOtherQuadrantsAngles(Dictionary<string, DeltaAngle> firstQuadrantAngles)
        {
            Dictionary<string, DeltaAngle> allQuadrantAngles = new Dictionary<string, DeltaAngle>();

            foreach (var firstQuadrantAngle in firstQuadrantAngles.Values)
            {
                if (!allQuadrantAngles.ContainsKey(firstQuadrantAngle.ToString()))
                {
                    allQuadrantAngles.Add(firstQuadrantAngle.ToString(), firstQuadrantAngle);
                }

                var secondQuadrantAngle = new DeltaAngle(-firstQuadrantAngle.X, firstQuadrantAngle.Y);
                if (!allQuadrantAngles.ContainsKey(secondQuadrantAngle.ToString()))
                {
                    allQuadrantAngles.Add(secondQuadrantAngle.ToString(), secondQuadrantAngle);
                }

                var thirdQuadrantAngle = new DeltaAngle(-firstQuadrantAngle.X, -firstQuadrantAngle.Y);
                if (!allQuadrantAngles.ContainsKey(thirdQuadrantAngle.ToString()))
                {
                    allQuadrantAngles.Add(thirdQuadrantAngle.ToString(), thirdQuadrantAngle);
                }

                var fourthQuadrantAngle = new DeltaAngle(firstQuadrantAngle.X, -firstQuadrantAngle.Y);
                if (!allQuadrantAngles.ContainsKey(fourthQuadrantAngle.ToString()))
                {
                    allQuadrantAngles.Add(fourthQuadrantAngle.ToString(), fourthQuadrantAngle);
                }
            }

            return allQuadrantAngles;
        }

        public DeltaAngle GetNextAngle()
        {
            DeltaAngle nextAngle = _angles[_index];
            _index = (_index + 1) % _angles.Length;
            return nextAngle;
        }
    }
}