using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Day3CrossedWires.Tests
{
    public class WirePointCalculatorTests
    {
        [Theory]
        [ClassData(typeof(WirePointCalculatorTestData))]
        public void WirePointCalculatorWorks(Point startingPoint, string command, WirePoint[] expectedWirePoints)
        {
            //Arrange

            //Act
            var actualWirePoints = WirePointCalculator.GetWirePoints(startingPoint, command).ToArray();

            //Assert
            for (int i = 0; i < expectedWirePoints.Length; i++)
            {
                Assert.Equal(expectedWirePoints[i].Point, actualWirePoints[i].Point);
                Assert.Equal(expectedWirePoints[i].Wire.IsHorizontal, actualWirePoints[i].Wire.IsHorizontal);
                Assert.Equal(expectedWirePoints[i].Wire.IsVertical, actualWirePoints[i].Wire.IsVertical);
            }
        }
    }

    public class WirePointCalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Point(-1, 5), "R5", new[]
                {
                    new WirePoint(Wire.HorizontalWire(), new Point(0, 5)),
                    new WirePoint(Wire.HorizontalWire(), new Point(1, 5)),
                    new WirePoint(Wire.HorizontalWire(), new Point(2, 5)),
                    new WirePoint(Wire.HorizontalWire(), new Point(3, 5)),
                    new WirePoint(Wire.HorizontalWire(), new Point(4, 5))
                }
            };
            yield return new object[]
            {
                new Point(1, 6), "L7", new[]
                {
                    new WirePoint(Wire.HorizontalWire(), new Point(0, 6)),
                    new WirePoint(Wire.HorizontalWire(), new Point(-1, 6)),
                    new WirePoint(Wire.HorizontalWire(), new Point(-2, 6)),
                    new WirePoint(Wire.HorizontalWire(), new Point(-3, 6)),
                    new WirePoint(Wire.HorizontalWire(), new Point(-4, 6)),
                    new WirePoint(Wire.HorizontalWire(), new Point(-5, 6)),
                    new WirePoint(Wire.HorizontalWire(), new Point(-6, 6)),
                }
            };
            yield return new object[]
            {
                new Point(3, 5), "U6", new[]
                {
                    new WirePoint(Wire.VerticalWire(), new Point(3, 6)),
                    new WirePoint(Wire.VerticalWire(), new Point(3, 7)),
                    new WirePoint(Wire.VerticalWire(), new Point(3, 8)),
                    new WirePoint(Wire.VerticalWire(), new Point(3, 9)),
                    new WirePoint(Wire.VerticalWire(), new Point(3, 10)),
                    new WirePoint(Wire.VerticalWire(), new Point(3, 11))
                }
            };
            yield return new object[]
            {
                new Point(2, 3), "D5", new[]
                {
                    new WirePoint(Wire.VerticalWire(), new Point(2, 2)),
                    new WirePoint(Wire.VerticalWire(), new Point(2, 1)),
                    new WirePoint(Wire.VerticalWire(), new Point(2, 0)),
                    new WirePoint(Wire.VerticalWire(), new Point(2, -1)),
                    new WirePoint(Wire.VerticalWire(), new Point(2, -2))
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
