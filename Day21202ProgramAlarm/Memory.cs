using System;
using System.Linq;

namespace Day21202ProgramAlarm
{
    public class Memory
    {
        private readonly int[] _cells;

        public Memory(int[] cells)
        {
            if (cells == null) throw new ArgumentNullException(nameof(cells));
            if (cells.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(cells));
            _cells = cells;
        }

        public int Size => _cells.Length;

        public int GetCellAt(int index) => _cells[index];

        public int[] GetInstructionStartingAt(int index, int instructionSize) => _cells.Skip(index).Take(instructionSize).ToArray();

        public void SetCellAt(int index, int data) => _cells[index] = data;
    }
}