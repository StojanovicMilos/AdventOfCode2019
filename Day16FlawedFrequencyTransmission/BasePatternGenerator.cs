using System;
using System.Collections.Generic;

namespace Day16FlawedFrequencyTransmission
{
    public interface IBasePatternGenerator
    {
        IEnumerable<int> GetBasePatternFor(int elementNumber);
    }

    public class BasePatternGenerator : IBasePatternGenerator
    {
        private static readonly int[] BasePattern = {0, 1, 0, -1};

        public IEnumerable<int> GetBasePatternFor(int elementNumber)
        {
            if (elementNumber < 0) throw new ArgumentOutOfRangeException(nameof(elementNumber));
            int index = 1; //skipping first element
            elementNumber++; //elementNumber should be ordinal number of the element in 1 index counting, while provided value is 0 index counting
            while (true)
            {
                yield return BasePattern[index / elementNumber];
                index = (index + 1) % (BasePattern.Length * elementNumber);
            }

            // ReSharper disable once IteratorNeverReturns
        }
    }
}