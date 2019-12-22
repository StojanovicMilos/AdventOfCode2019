using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14SpaceStoichiometry
{
    public static class InputParser
    {
        public static List<Reaction> Parse(string input)
        {
            List<Reaction> list = new List<Reaction>();
            foreach (var line in input.Split(Environment.NewLine))
            {
                string inputs = line.Split("=>")[0].Trim();
                string output = line.Split("=>")[1].Trim();
                list.Add(new Reaction(inputs.Split(',').Select(i => new ReactionComponent(i.Trim())).ToList(), new ReactionComponent(output)));
            }

            return list;
        }
    }
}