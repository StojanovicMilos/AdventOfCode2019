using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6UniversalOrbitMap
{
    public class OrbitingObjects
    {
        private readonly Dictionary<string, ObjectOrbitsAround> _orbitingObjects;

        public OrbitingObjects(string input)
        {
            _orbitingObjects = new Dictionary<string, ObjectOrbitsAround>();
            foreach (var line in input.Split(Environment.NewLine.ToCharArray()).Where(s => !string.IsNullOrEmpty(s)))
            {
                string centerObjectKey = line.Split(')')[0];
                string orbitingObjectKey = line.Split(')')[1];
                ObjectOrbitsAround centerOrbitingObject = AddToOrbitingObjects(centerObjectKey);
                ObjectOrbitsAround orbitingObject = AddToOrbitingObjects(orbitingObjectKey);
                orbitingObject.AddOrbitsAround(centerOrbitingObject);
            }
        }

        private ObjectOrbitsAround AddToOrbitingObjects(string orbitingObjectKey)
        {
            if (!_orbitingObjects.ContainsKey(orbitingObjectKey))
                _orbitingObjects.Add(orbitingObjectKey, new ObjectOrbitsAround());
            return _orbitingObjects[orbitingObjectKey];
        }

        public int DistanceToSanta() => DistanceBetween(_orbitingObjects["YOU"], _orbitingObjects["SAN"]);

        private static int DistanceBetween(ObjectOrbitsAround start, ObjectOrbitsAround end)
        {

            List<ObjectOrbitsAround> startAncestor = start.GetAncestor();
            List<ObjectOrbitsAround> endAncestor = end.GetAncestor();

            ObjectOrbitsAround commonAncestor = startAncestor.Intersect(endAncestor).First();

            return startAncestor.IndexOf(commonAncestor) + endAncestor.IndexOf(commonAncestor);
        }

        public int CountTotalNumberOfOrbits() => _orbitingObjects.Sum(o => o.Value.CountTotalNumberOfOrbits());
    }
}