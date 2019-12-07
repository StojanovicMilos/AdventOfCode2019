using System.Collections.Generic;
using System.Linq;

namespace Day6UniversalOrbitMap
{
    public class ObjectOrbitsAround
    {
        private readonly List<ObjectOrbitsAround> _otherObjects;

        public ObjectOrbitsAround()
        {
            _otherObjects = new List<ObjectOrbitsAround>();
        }

        public void AddOrbitsAround(ObjectOrbitsAround otherObject) => _otherObjects.Add(otherObject);

        private int CountDirectOrbits() => _otherObjects.Count;

        private int CountIndirectOrbits() => _otherObjects.Sum(o => o.CountTotalNumberOfOrbits());

        public int CountTotalNumberOfOrbits() => CountDirectOrbits() + CountIndirectOrbits();
    }
}