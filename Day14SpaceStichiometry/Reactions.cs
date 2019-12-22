using System.Collections.Generic;
using System.Linq;

namespace Day14SpaceStoichiometry
{
    public class Reactions
    {
        private readonly List<Reaction> _reactions;

        public Reactions(List<Reaction> reactions)
        {
            _reactions = reactions;
        }

        public int GetNumberOfOresNeededForFuel() =>
            _reactions
                .First(r => r.Output.Name == "FUEL")
                .GetNumberOfOresNeededForOutput(_reactions, 1, new RemainingReactionComponents());
    }
}