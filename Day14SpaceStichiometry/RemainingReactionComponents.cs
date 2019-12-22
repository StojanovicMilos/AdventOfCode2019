using System;
using System.Collections.Generic;
using System.Numerics;

namespace Day14SpaceStoichiometry
{
    public class RemainingReactionComponents
    {
        private readonly Dictionary<string, BigInteger> _remaining = new Dictionary<string, BigInteger>();

        public BigInteger GetNumberOf(string componentName) => _remaining.ContainsKey(componentName) ? _remaining[componentName] : 0;

        public void Add(string componentName, BigInteger count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            if(count == 0) return;
            if (_remaining.ContainsKey(componentName))
                _remaining[componentName] += count;
            else
                _remaining[componentName] = count;
        }

        public void Remove(string componentName, BigInteger count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            if(count == 0) return;
            if (_remaining.ContainsKey(componentName) && _remaining[componentName] >= count)
                _remaining[componentName] -= count;
            else throw new ArgumentException($"you do not have enough {componentName} in storage.");
        }
    }
}