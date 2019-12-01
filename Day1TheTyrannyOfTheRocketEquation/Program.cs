using System;
using System.IO;
using System.Linq;

namespace Day1TheTyrannyOfTheRocketEquation
{
    public static class Program
    {
        static void Main()
        {
            Console.WriteLine(File.ReadAllLines("Masses.txt").Sum(mass => CalculateFuelRequirement(Convert.ToInt32(mass))));
        }

        public static int CalculateFuelRequirement(int mass) => mass / 3 - 2;
    }
}
