using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Day10MonitoringStation.Tests
{
    public class DeltaAngleTests
    {
        [Theory]
        [ClassData(typeof(DeltaAngleTestData))]
        public void GetNumberOfVisibleDeltaAnglesWorks(DeltaAngle deltaAngle, int expectedAngle)
        {
            //Arrange

            //Act 
            var actualAngle = deltaAngle.Angle;

            //Assert
            Assert.Equal(expectedAngle, actualAngle);
        }
    }

    public class DeltaAngleTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new DeltaAngle(0, -1),
                0
            };

            yield return new object[]
            {
                new DeltaAngle(1, -1),
                45
            };

            yield return new object[]
            {
                new DeltaAngle(1, 0),
                90
            };

            yield return new object[]
            {
                new DeltaAngle(1, 1),
                135
            };

            yield return new object[]
            {
                new DeltaAngle(0, 1),
                180
            };

            yield return new object[]
            {
                new DeltaAngle(-1, 1),
                225
            };

            yield return new object[]
            {
                new DeltaAngle(-1, 0),
                270
            };

            yield return new object[]
            {
                new DeltaAngle(-1, -1),
                315
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
