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
