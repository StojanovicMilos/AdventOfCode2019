using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Day21202ProgramAlarm.Tests
{
    public class ProgramAlarmTests
    {
        [Theory]
        [ClassData(typeof(ProgramAlarmTestData))]
        public void CharacterCountWorks(int[] initialData, int[] expectedData)
        {
            //Arrange
            Memory memory = new Memory(initialData);
            Instructions instructions = new Instructions(memory);

            //Act
            instructions.Execute();

            //Assert
            for (int i = 0; i < expectedData.Length; i++)
            {
                Assert.Equal(expectedData[i], memory.GetCellAt(i));
            }
        }

        [Fact]
        public void PartTwoTest()
        {
            //Arrange
            const int expectedValue = 19690720;
            var initialData = new[] {1, 53, 79, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 1, 6, 19, 1, 9, 19, 23, 1, 6, 23, 27, 1, 10, 27, 31, 1, 5, 31, 35, 2, 6, 35, 39, 1, 5, 39, 43, 1, 5, 43, 47, 2, 47, 6, 51, 1, 51, 5, 55, 1, 13, 55, 59, 2, 9, 59, 63, 1, 5, 63, 67, 2, 67, 9, 71, 1, 5, 71, 75, 2, 10, 75, 79, 1, 6, 79, 83, 1, 13, 83, 87, 1, 10, 87, 91, 1, 91, 5, 95, 2, 95, 10, 99, 2, 9, 99, 103, 1, 103, 6, 107, 1, 107, 10, 111, 2, 111, 10, 115, 1, 115, 6, 119, 2, 119, 9, 123, 1, 123, 6, 127, 2, 127, 10, 131, 1, 131, 6, 135, 2, 6, 135, 139, 1, 139, 5, 143, 1, 9, 143, 147, 1, 13, 147, 151, 1, 2, 151, 155, 1, 10, 155, 0, 99, 2, 14, 0, 0};
            Memory memory = new Memory(initialData);
            Instructions instructions = new Instructions(memory);

            //Act
            instructions.Execute();

            //Assert
            Assert.Equal(expectedValue, memory.GetCellAt(0));
        }
    }

    public class ProgramAlarmTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new[] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 }, new[] { 3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50 } };
            yield return new object[] { new[] { 1, 0, 0, 0, 99 }, new[] { 2, 0, 0, 0, 99 } };
            yield return new object[] { new[] { 2, 3, 0, 3, 99 }, new[] { 2, 3, 0, 6, 99 } };
            yield return new object[] { new[] { 2, 4, 4, 5, 99, 0 }, new[] { 2, 4, 4, 5, 99, 9801 } };
            yield return new object[] { new[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, new[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
