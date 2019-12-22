﻿using System;

namespace Day14SpaceStoichiometry
{
    class Program
    {
        static void Main()
        {
            string input = @"9 ORE => 2 A
8 ORE => 3 B
7 ORE => 5 C
3 A, 4 B => 1 AB
5 B, 7 C => 1 BC
4 C, 1 A => 1 CA
2 AB, 3 BC, 4 CA => 1 FUEL";

            Reactions reactions = new Reactions(InputParser.Parse(input));

            Console.WriteLine(reactions.GetNumberOfOresNeededForFuel());
        }
    }
}
