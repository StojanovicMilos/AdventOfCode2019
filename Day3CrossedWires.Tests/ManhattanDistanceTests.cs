using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Day3CrossedWires.Tests
{
    public class ManhattanDistanceTests
    {
        [Theory]
        [ClassData(typeof(ManhattanDistanceToOriginTestData))]
        public void ManhattanDistanceToOriginWorks(Point point, int expectedDistance)
        {
            Assert.Equal(expectedDistance, ManhattanDistance.ToOrigin(point));
        }

        [Theory]
        [ClassData(typeof(ManhattanDistanceBetweenTestData))]
        public void ManhattanDistanceBetweenWorks(Point point1, Point point2, int expectedDistance)
        {
            Assert.Equal(expectedDistance, ManhattanDistance.Between(point1, point2));
        }
    }

    public class ManhattanDistanceToOriginTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {new Point(-1, 5), 6};
            yield return new object[] {new Point(1, 6), 7};
            yield return new object[] {new Point(3, 5), 8};
            yield return new object[] {new Point(2, 3), 5};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ManhattanDistanceBetweenTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {new Point(-1, 5), new Point(1, 6), 3};
            yield return new object[] {new Point(-1, 5), new Point(3, 5), 4};
            yield return new object[] {new Point(-1, 5), new Point(2, 3), 5};
            yield return new object[] {new Point(2, 3), new Point(3, 5), 3};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
