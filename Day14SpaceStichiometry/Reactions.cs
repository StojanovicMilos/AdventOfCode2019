using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Day14SpaceStoichiometry
{
    public class Reactions
    {
        private readonly List<Reaction> _reactions;

        public Reactions(List<Reaction> reactions)
        {
            _reactions = reactions;
        }

        public BigInteger GetNumberOfOresNeededForFuel() => GetNumberOfOresNeededForFuel(new BigInteger(1));

        private BigInteger GetNumberOfOresNeededForFuel(BigInteger fuelQuantity) =>
            _reactions
                .First(r => r.Output.Name == "FUEL")
                .GetNumberOfOresNeededForOutput(_reactions, fuelQuantity, new RemainingReactionComponents());

        public BigInteger GetFuelQuantityForTrillionOre()
        {
            BigInteger oreQuantity = 1000000000000;

            BigInteger requiredOreForOneFuel = GetNumberOfOresNeededForFuel(new BigInteger(1));

            BigInteger lower = oreQuantity / requiredOreForOneFuel - 1000;
            BigInteger higher = oreQuantity / requiredOreForOneFuel + 1000000000;

            while (lower < higher)
            {
                BigInteger middle = (lower + higher) / 2;
                BigInteger guess = GetNumberOfOresNeededForFuel(middle);
                if (guess == oreQuantity)
                    break;

                if (guess > oreQuantity)
                {
                    higher = middle;
                }
                else if (guess < oreQuantity)
                {
                    if (middle == lower) break;
                    lower = middle;
                }
            }

            return lower;
        }
    }
}