using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class Memory
    {
        private readonly Dictionary<BigInteger, BigInteger> _cells = new Dictionary<BigInteger, BigInteger>();
        private BigInteger _currentCellIndex;
        private BigInteger _relativeBase;


        private const int DefaultStartingCellIndex = 0;
        private const int DefaultRelativeBase = 0;

        public Memory(BigInteger[] cells) : this(cells, DefaultStartingCellIndex, DefaultRelativeBase)
        {

        }

        public Memory(BigInteger[] cells, int startingCellIndex, int relativeBase)
        {
            if (cells == null) throw new ArgumentNullException(nameof(cells));
            if (cells.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(cells));
            if (startingCellIndex < 0 || startingCellIndex > cells.Length - 1) throw new ArgumentOutOfRangeException(nameof(startingCellIndex));
            if (relativeBase < 0) throw new ArgumentOutOfRangeException(nameof(relativeBase));
            for (int i = 0; i < cells.Length; i++)
            {
                _cells.Add(i, cells[i]);
            }
            _currentCellIndex = startingCellIndex;
            _relativeBase = relativeBase;
        }

        public BigInteger GetNextByte()
        {
            BigInteger nextByte = _cells[_currentCellIndex];
            _currentCellIndex++;
            return nextByte;
        }

        public void SetCurrentCellIndex(BigInteger newCellIndex) => _currentCellIndex = newCellIndex;

        public void SetCurrentCellIndexRelative(BigInteger delta) => SetCurrentCellIndex(_currentCellIndex + delta);

        public void SetCellAt(BigInteger index, BigInteger data) => _cells[index] = data;

        public void SetCellAtRelative(BigInteger relativeAddress, BigInteger data) => _cells[_relativeBase + relativeAddress] = data;

        private const int DefaultCellValue = 0;

        public BigInteger GetCellAt(BigInteger index)
        {
            if (_cells.ContainsKey(index))
                return _cells[index];

            _cells.Add(index, DefaultCellValue);
            return _cells[index];
        }

        public override string ToString() => string.Join(',', _cells.Select(c => c.ToString()));

        public BigInteger GetCellAtRelative(BigInteger relativeAddress) => GetCellAt(_relativeBase + relativeAddress);

        public void AdjustRelativeBase(BigInteger relativeBase) => _relativeBase += relativeBase;
    }
}