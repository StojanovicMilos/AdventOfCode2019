using Xunit;

namespace Day4SecureContainer.Tests
{
    public class CompositePasswordRulesTests
    {
        [Theory]
        [InlineData(111111, true)]
        [InlineData(223450, false)]
        [InlineData(123789, false)]
        public void CompositePasswordRulesPart1Work(int password, bool expectedResult)
        {
            //Arrange
            IPasswordRule composite = CompositePasswordRules.RulesPart1();

            //Act
            var actualResult = composite.IsValid(password);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }


        [Theory]
        [InlineData(112233, true)]
        [InlineData(123444, false)]
        [InlineData(111122, true)]
        public void CompositePasswordRulesPart2Work(int password, bool expectedResult)
        {
            //Arrange
            IPasswordRule composite = CompositePasswordRules.RulesPart2();

            //Act
            var actualResult = composite.IsValid(password);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
