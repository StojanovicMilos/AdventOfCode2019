using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Day16FlawedFrequencyTransmission.Tests
{
    public class BasePatternGeneratorTests
    {
        [Theory]
        [ClassData(typeof(BasePatternGeneratorTestData))]
        public void BasePatternGeneratorTestsWorks(int elementNumber, int[] expectedResult)
        {
            //Arrange
            IBasePatternGenerator basePatternGenerator = new BasePatternGenerator();

            //Act
            var actualResult = basePatternGenerator.GetBasePatternFor(elementNumber).Take(expectedResult.Length).ToArray();

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }

    public class BasePatternGeneratorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                0,
                new[] {1, 0, -1}
            };

            yield return new object[]
            {
                0,
                new[] {1, 0, -1, 0, 1, 0, -1}
            };

            yield return new object[]
            {
                1,
                new[] {0, 1, 1, 0, 0, -1, -1}
            };

            yield return new object[]
            {
                1,
                new[] {0, 1, 1, 0, 0, -1, -1, 0, 0, 1, 1, 0, 0, -1, -1}
            };

            yield return new object[]
            {
                2,
                new[] {0, 0, 1, 1, 1, 0, 0, 0, -1, -1, -1}
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
