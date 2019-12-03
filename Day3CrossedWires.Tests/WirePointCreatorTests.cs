using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Day3CrossedWires.Tests
{
    public class WirePointCreatorTests
    {
        [Theory]
        [ClassData(typeof(WirePointCreatorTestData))]
        public void WirePointCreatorWorks(string commands, WireStepPoint[] expectedWirePoints)
        {
            //Arrange

            //Act
            var actualWirePoints = WirePointCreator.GetWireStepPoints(commands).ToArray();

            //Assert
            for (int i = 0; i < expectedWirePoints.Length; i++)
            {
                Assert.Equal(expectedWirePoints[i].Point, actualWirePoints[i].Point);
                Assert.Equal(expectedWirePoints[i].WireStep.IsHorizontal, actualWirePoints[i].WireStep.IsHorizontal);
                Assert.Equal(expectedWirePoints[i].WireStep.IsVertical, actualWirePoints[i].WireStep.IsVertical);
            }
        }
    }

    public class WirePointCreatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                "R5", new[]
                {
                    new WireStepPoint(WireStep.HorizontalWire(), new Point(1, 0)),
                    new WireStepPoint(WireStep.HorizontalWire(), new Point(2, 0)),
                    new WireStepPoint(WireStep.HorizontalWire(), new Point(3, 0)),
                    new WireStepPoint(WireStep.HorizontalWire(), new Point(4, 0)),
                    new WireStepPoint(WireStep.HorizontalWire(), new Point(5, 0))
                }
            };
            yield return new object[]
            {
                "L7", new[]
                {
                    new WireStepPoint(WireStep.HorizontalWire(), new Point(-1, 0)),
                    new WireStepPoint(WireStep.HorizontalWire(), new Point(-2, 0)),
                    new WireStepPoint(WireStep.HorizontalWire(), new Point(-3, 0)),
                    new WireStepPoint(WireStep.HorizontalWire(), new Point(-4, 0)),
                    new WireStepPoint(WireStep.HorizontalWire(), new Point(-5, 0)),
                    new WireStepPoint(WireStep.HorizontalWire(), new Point(-6, 0)),
                    new WireStepPoint(WireStep.HorizontalWire(), new Point(-7,  0))
                }
            };
            yield return new object[]
            {
                "U6", new[]
                {
                    new WireStepPoint(WireStep.VerticalWire(), new Point(0, 1)),
                    new WireStepPoint(WireStep.VerticalWire(), new Point(0, 2)),
                    new WireStepPoint(WireStep.VerticalWire(), new Point(0, 3)),
                    new WireStepPoint(WireStep.VerticalWire(), new Point(0, 4)),
                    new WireStepPoint(WireStep.VerticalWire(), new Point(0, 5)),
                    new WireStepPoint(WireStep.VerticalWire(), new Point(0, 6))
                }
            };
            yield return new object[]
            {
                "D5", new[]
                {
                    new WireStepPoint(WireStep.VerticalWire(), new Point(0, -1)),
                    new WireStepPoint(WireStep.VerticalWire(), new Point(0, -2)),
                    new WireStepPoint(WireStep.VerticalWire(), new Point(0, -3)),
                    new WireStepPoint(WireStep.VerticalWire(), new Point(0, -4)),
                    new WireStepPoint(WireStep.VerticalWire(), new Point(0, -5))
                }
            };
            yield return new object[]
            {
                "R4,U2", new[]
                {
                    new WireStepPoint(WireStep.HorizontalWire(), new Point(1, 0)),
                    new WireStepPoint(WireStep.HorizontalWire(), new Point(2, 0)),
                    new WireStepPoint(WireStep.HorizontalWire(), new Point(3, 0)),
                    new WireStepPoint(WireStep.HorizontalWire(), new Point(4, 0)),
                    new WireStepPoint(WireStep.VerticalWire(), new Point(4, 1)),
                    new WireStepPoint(WireStep.VerticalWire(), new Point(4, 2))
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}