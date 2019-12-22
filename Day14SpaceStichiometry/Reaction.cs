using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

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

        public BigInteger GetNumberOfOresNeededForOutput(List<Reaction> allReactions, BigInteger neededQuantity, RemainingReactionComponents remainingReactionComponents)
        {
            BigInteger numberOfNeededReactions = new BigInteger(Math.Ceiling((decimal) neededQuantity / (decimal) Output.Quantity));
            if (numberOfNeededReactions == 0)
                return 0;

            BigInteger extraOutputComponents = numberOfNeededReactions * Output.Quantity - neededQuantity;
            remainingReactionComponents.Add(Output.Name, extraOutputComponents);

            BigInteger sum = 0;
            foreach (var reactionComponent in _inputs)
            {
                if (reactionComponent.Name == "ORE")
                {
                    BigInteger usedOre = numberOfNeededReactions * reactionComponent.Quantity;
                    sum += usedOre;
                }
                else
                {
                    BigInteger remainingReactionComponentQuantity = remainingReactionComponents.GetNumberOf(reactionComponent.Name);
                    if (numberOfNeededReactions * reactionComponent.Quantity <= remainingReactionComponentQuantity) //we already have enough quantity of this component from previous reactions
                    {
                        BigInteger usedQuantity = numberOfNeededReactions * reactionComponent.Quantity;
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