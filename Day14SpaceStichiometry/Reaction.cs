using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14SpaceStoichiometry
{
    public class Reaction
    {
        private readonly List<ReactionComponent> _inputs;
        public ReactionComponent Output { get; }

        public Reaction(List<ReactionComponent> inputs, ReactionComponent output)
        {
            if (inputs == null) throw new ArgumentNullException(nameof(inputs));
            if (inputs.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(inputs));
            _inputs = inputs;
            Output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public int GetNumberOfOresNeededForOutput(List<Reaction> allReactions, int neededQuantity, RemainingReactionComponents remainingReactionComponents)
        {
            int numberOfNeededReactions = (int) Math.Ceiling((decimal) neededQuantity / Output.Quantity);
            if (numberOfNeededReactions == 0)
                return 0;

            int extraOutputComponents = numberOfNeededReactions * Output.Quantity - neededQuantity;
            remainingReactionComponents.Add(Output.Name, extraOutputComponents);

            int sum = 0;
            foreach (var reactionComponent in _inputs)
            {
                if (reactionComponent.Name == "ORE")
                {
                    int usedOre = numberOfNeededReactions * reactionComponent.Quantity;
                    sum += usedOre;
                }
                else
                {
                    int remainingReactionComponentQuantity = remainingReactionComponents.GetNumberOf(reactionComponent.Name);
                    if (numberOfNeededReactions * reactionComponent.Quantity <= remainingReactionComponentQuantity) //we already have enough quantity of this component from previous reactions
                    {
                        int usedQuantity = numberOfNeededReactions * reactionComponent.Quantity;
                        remainingReactionComponents.Remove(reactionComponent.Name, usedQuantity);
                    }
                    else
                    {
                        remainingReactionComponents.Remove(reactionComponent.Name, remainingReactionComponentQuantity);

                        sum += allReactions
                            .First(r => r.Output.Name == reactionComponent.Name)
                            .GetNumberOfOresNeededForOutput(allReactions, numberOfNeededReactions * reactionComponent.Quantity - remainingReactionComponentQuantity, remainingReactionComponents);
                    }
                }
            }

            return sum;
        }
    }
}