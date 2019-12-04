using Xunit;

namespace Day4SecureContainer.Tests
{
    public class CompositePasswordRulesTests
    {
        [Theory]
        [InlineData(111111, true)]
        [InlineData(223450, false)]
        [InlineData(123789, false)]
        public void CompositePasswordRulesWork(int password, bool expectedResult)
        {
            //Arrange
            IPasswordRule composite = CompositePasswordRules.DefaultRules();

            //Act
            var actualResult = composite.IsValid(password);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

    }
}
