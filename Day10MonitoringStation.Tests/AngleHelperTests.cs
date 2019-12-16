using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Day10MonitoringStation.Tests
{
    public class AngleHelperTests
    {
        [Theory]
        [ClassData(typeof(AngleHelperTestData))]
        public void GetNumberOfVisibleDeltaAnglesWorks(int biggestXCoordinate, int biggestYCoordinate, DeltaAngle[] expectedAngles)
        {
            //Arrange
            AngleHelper angleHelper = new AngleHelper(biggestXCoordinate, biggestYCoordinate);

            //Act + Assert
            foreach (var expectedAngle in expectedAngles)
            {
                var actualAngle = angleHelper.GetNextAngle();
                Assert.Equal(expectedAngle.ToString(), actualAngle.ToString());
            }
        }
    }

    public class AngleHelperTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                1, 0, new[] {new DeltaAngle(1, 0), new DeltaAngle(-1, 0)}
            };

            yield return new object[]
            {
                0, 1, new[] {new DeltaAngle(0, -1), new DeltaAngle(0, 1)}
            };

            yield return new object[]
            {
                1, 1, new[] {new DeltaAngle(0, -1), new DeltaAngle(1, -1), new DeltaAngle(1, 0), new DeltaAngle(1, 1), new DeltaAngle(0, 1), new DeltaAngle(-1, 1), new DeltaAngle(-1, 0), new DeltaAngle(-1, -1)}
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
