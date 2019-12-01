using Xunit;

namespace Day1TheTyrannyOfTheRocketEquation.Tests
{
    public class FuelRequirementCalculationTests
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void CalculateFuelRequirement_CalculatesCorrectly(int mass, int expectedResult)
        {
            Assert.Equal(expectedResult, Program.CalculateFuelRequirement(mass));
        }

        [Theory]
        [InlineData(14, 2)]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void CalculateAdvancedFuelRequirement_CalculatesCorrectly(int mass, int expectedResult)
        {
            Assert.Equal(expectedResult, Program.CalculateAdvancedFuelRequirement(mass));
        }
    }
}
