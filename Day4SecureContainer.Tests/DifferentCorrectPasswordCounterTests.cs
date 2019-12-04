using Xunit;

namespace Day4SecureContainer.Tests
{
    public class DifferentCorrectPasswordCounterTests
    {

        [Theory]
        [InlineData("111111-111112", 2)]
        [InlineData("111111-111120", 9)]
        [InlineData("254032-789860", 1033)]
        public void DifferentCorrectPasswordCounterPart1Works(string range, int expectedResult)
        {
            //Arrange
            DifferentCorrectPasswordCounter differentCorrectPasswordCounter = new DifferentCorrectPasswordCounter(CompositePasswordRules.DefaultRulesPart1());

            //Act
            var actualResult = differentCorrectPasswordCounter.CountPasswordsIn(range);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("254032-789860", 670)]
        public void DifferentCorrectPasswordCounterPart2Works(string range, int expectedResult)
        {
            //Arrange
            DifferentCorrectPasswordCounter differentCorrectPasswordCounter = new DifferentCorrectPasswordCounter(CompositePasswordRules.DefaultRulesPart2());

            //Act
            var actualResult = differentCorrectPasswordCounter.CountPasswordsIn(range);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

    }
}