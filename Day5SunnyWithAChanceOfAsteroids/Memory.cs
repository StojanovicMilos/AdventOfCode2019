using System;
using System.Linq;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class Memory
    {
        private readonly int[] _cells;
        private int _currentCellIndex;

        public Memory(int[] cells) : this(cells, 0)
        {

        }

        public Memory(int[] cells, int startingCellIndex)
        {
            if (cells == null) throw new ArgumentNullException(nameof(cells));
            if (cells.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(cells));
            if (startingCellIndex < 0 || startingCellIndex > cells.Length - 1) throw new ArgumentOutOfRangeException(nameof(startingCellIndex));
            _cells = cells;
            _currentCellIndex = startingCellIndex;
        }

        public int GetNextByte()
        {
            int nextByte = _cells[_currentCellIndex];
            _currentCellIndex++;
            return nextByte;
        }

        public void SetCellAt(int index, int data) => _cells[index] = data;

        public int GetCellAt(int index) => _cells[index];

        public override string ToString() => string.Join(',', _cells.Select(c => c.ToString()));
    }
}