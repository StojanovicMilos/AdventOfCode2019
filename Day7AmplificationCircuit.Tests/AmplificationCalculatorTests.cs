using System.Collections;
using System.Collections.Generic;
using Day5SunnyWithAChanceOfAsteroids;
using Xunit;

namespace Day7AmplificationCircuit.Tests
{
    public class AmplificationCalculatorTests
    {
        [Theory]
        [ClassData(typeof(AmplificationCalculatorTestData))]
        public void AmplificationCalculatorWorks(int[] cells, InstructionResult[] phaseSettings, InstructionResult initialInstruction, int expectedResult)
        {
            //Arrange

            //Act
            var actualResult = AmplificationCalculator.CalculateAmplification(cells, phaseSettings, initialInstruction);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }

    public class AmplificationCalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new[] {3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0}, new[]
                {
                    InstructionResult.NonBreakInstructionResult(4, 0),
                    InstructionResult.NonBreakInstructionResult(3, 0),
                    InstructionResult.NonBreakInstructionResult(2, 0),
                    InstructionResult.NonBreakInstructionResult(1, 0),
                    InstructionResult.NonBreakInstructionResult(0, 0)
                },
                InstructionResult.NonBreakInstructionResult(0, 0), 43210
            };
            yield return new object[]
            {
                new[] {3, 23, 3, 24, 1002, 24, 10, 24, 1002, 23, -1, 23, 101, 5, 23, 23, 1, 24, 23, 23, 4, 23, 99, 0, 0}, new[]
                {
                    InstructionResult.NonBreakInstructionResult(0, 0),
                    InstructionResult.NonBreakInstructionResult(1, 0),
                    InstructionResult.NonBreakInstructionResult(2, 0),
                    InstructionResult.NonBreakInstructionResult(3, 0),
                    InstructionResult.NonBreakInstructionResult(4, 0)
                },
                InstructionResult.NonBreakInstructionResult(0, 0), 54321
            };
            yield return new object[]
            {
                new[] {3, 31, 3, 32, 1002, 32, 10, 32, 1001, 31, -2, 31, 1007, 31, 0, 33, 1002, 33, 7, 33, 1, 33, 31, 31, 1, 32, 31, 31, 4, 31, 99, 0, 0, 0}, new[]
                {
                    InstructionResult.NonBreakInstructionResult(1, 0),
                    InstructionResult.NonBreakInstructionResult(0, 0),
                    InstructionResult.NonBreakInstructionResult(4, 0),
                    InstructionResult.NonBreakInstructionResult(3, 0),
                    InstructionResult.NonBreakInstructionResult(2, 0)
                },
                InstructionResult.NonBreakInstructionResult(0, 0), 65210
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
