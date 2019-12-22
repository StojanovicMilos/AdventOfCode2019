using System;
using System.Collections.Generic;

namespace Day14SpaceStoichiometry
{
    public class RemainingReactionComponents
    {
        private readonly Dictionary<string, int> _remaining = new Dictionary<string, int>();

        public int GetNumberOf(string componentName) => _remaining.ContainsKey(componentName) ? _remaining[componentName] : 0;

        public void Add(string componentName, int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            if(count == 0) return;
            if (_remaining.ContainsKey(componentName))
                _remaining[componentName] += count;
            else
                _remaining[componentName] = count;
        }

        public void Remove(string componentName, int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            if(count == 0) return;
            if (_remaining.ContainsKey(componentName) && _remaining[componentName] >= count)
                _remaining[componentName] -= count;
            else throw new ArgumentException($"you do not have enough {componentName} in storage.");
        }
    }
}