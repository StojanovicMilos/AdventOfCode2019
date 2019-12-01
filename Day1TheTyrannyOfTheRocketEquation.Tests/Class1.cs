using System;
using Xunit;
using Day1TheTyrannyOfTheRocketEquation;

namespace Day1TheTyrannyOfTheRocketEquation.Tests
{
    public class Class1
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

    }
}
