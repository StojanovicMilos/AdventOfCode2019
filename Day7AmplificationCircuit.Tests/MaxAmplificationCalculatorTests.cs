﻿using System.Collections;
using System.Collections.Generic;
using Day5SunnyWithAChanceOfAsteroids;
using Xunit;

namespace Day7AmplificationCircuit.Tests
{

    public class MaxAmplificationCalculatorTests
    {
        [Theory]
        [ClassData(typeof(MaxAmplificationCalculatorTestData))]
        public void AmplificationCalculatorWorks(int phaseSettingsMin, int phaseSettingsMax, int[] cells, InstructionResult initialInstruction, int expectedResult)
        {
            //Arrange

            //Act
            var actualResult = MaxAmplificationCalculator.CalculateMaxAmplification(phaseSettingsMin, phaseSettingsMax, cells, initialInstruction);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }

    public class MaxAmplificationCalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {0, 4, new[] {3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0}, InstructionResult.NonBreakInstructionResult(0, 0), 43210};
            yield return new object[] {0, 4, new[] {3, 23, 3, 24, 1002, 24, 10, 24, 1002, 23, -1, 23, 101, 5, 23, 23, 1, 24, 23, 23, 4, 23, 99, 0, 0}, InstructionResult.NonBreakInstructionResult(0, 0), 54321};
            yield return new object[] {0, 4, new[] {3, 31, 3, 32, 1002, 32, 10, 32, 1001, 31, -2, 31, 1007, 31, 0, 33, 1002, 33, 7, 33, 1, 33, 31, 31, 1, 32, 31, 31, 4, 31, 99, 0, 0, 0}, InstructionResult.NonBreakInstructionResult(0, 0), 65210};

            yield return new object[] {5, 9, new[] {3, 26, 1001, 26, -4, 26, 3, 27, 1002, 27, 2, 27, 1, 27, 26, 27, 4, 27, 1001, 28, -1, 28, 1005, 28, 6, 99, 0, 0, 5}, InstructionResult.NonBreakInstructionResult(0, 0), 139629729};
            yield return new object[] {5, 9, new[] {3, 52, 1001, 52, -5, 52, 3, 53, 1, 52, 56, 54, 1007, 54, 5, 55, 1005, 55, 26, 1001, 54, -5, 54, 1105, 1, 12, 1, 53, 54, 53, 1008, 54, 0, 55, 1001, 55, 1, 55, 2, 53, 55, 53, 4, 53, 1001, 56, -1, 56, 1005, 56, 6, 99, 0, 0, 0, 0, 10}, InstructionResult.NonBreakInstructionResult(0, 0), 18216};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
