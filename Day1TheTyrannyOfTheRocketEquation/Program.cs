using System;
using System.IO;
using System.Linq;

namespace Day1TheTyrannyOfTheRocketEquation
{
    public static class Program
    {
        static void Main()
        {
            var masses = File.ReadAllLines("Masses.txt").Select(mass => Convert.ToInt32(mass)).ToArray();
            Console.WriteLine(masses.Sum(CalculateFuelRequirement));
            Console.WriteLine(masses.Sum(CalculateAdvancedFuelRequirement));
        }

        public static int CalculateFuelRequirement(int mass) => mass / 3 - 2;

        public static int CalculateAdvancedFuelRequirement(int mass)
        {
            int sum = 0;
            int fuel = CalculateFuelRequirement(mass);
            while (fuel > 0)
            {
                sum += fuel;
                fuel = CalculateFuelRequirement(fuel);
            }

            return sum;
        }
    }

}
