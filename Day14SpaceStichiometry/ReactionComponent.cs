using System;

namespace Day14SpaceStoichiometry
{
    public class ReactionComponent
    {
        public int Quantity { get; }
        public string Name { get; }

        public ReactionComponent(string input)
        {
            Quantity = Convert.ToInt32(input.Split(' ')[0].Trim());
            Name = input.Split(' ')[1].Trim();
        }
    }
}