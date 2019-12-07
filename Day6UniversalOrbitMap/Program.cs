using System;

namespace Day6UniversalOrbitMap
{
    class Program
    {
        static void Main()
        {
            string input = @"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L";
            OrbitingObjects orbitingObjects = new OrbitingObjects(input);
            Console.WriteLine(orbitingObjects.CountTotalNumberOfOrbits());
        }
    }
}
