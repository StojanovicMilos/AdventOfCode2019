using System;
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

        public void AddOrbitsAround(ObjectOrbitsAround otherObject)
        {
            if (_otherObjects.Count >= 1)
                throw new Exception("object can only orbit around one other object");
            _otherObjects.Add(otherObject);
        }

        private int CountDirectOrbits() => _otherObjects.Count;

        private int CountIndirectOrbits() => _otherObjects.Sum(o => o.CountTotalNumberOfOrbits());

        public int CountTotalNumberOfOrbits() => CountDirectOrbits() + CountIndirectOrbits();

        public List<ObjectOrbitsAround> GetAncestor()
        {
            if (!_otherObjects.Any())
                return new List<ObjectOrbitsAround>();

            ObjectOrbitsAround parent = _otherObjects.First();
            var ancestors = new List<ObjectOrbitsAround> {parent};
            ancestors.AddRange(parent.GetAncestor());
            return ancestors;
        }
    }
}