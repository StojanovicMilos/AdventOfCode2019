using Day5SunnyWithAChanceOfAsteroids;

namespace Day7AmplificationCircuit
{
    public static class MaxAmplificationCalculator
    {
        public static int CalculateMaxAmplification(int numberOfAmplifiers, int[] cells, InstructionResult initialInstructionResult)
        {

            int max = int.MinValue;

            foreach (var permutation in GetPermutations(numberOfAmplifiers))
            {
                InstructionResult[] phaseSettings = new InstructionResult[numberOfAmplifiers];
                for (int i = 0; i < phaseSettings.Length; i++)
                {
                    phaseSettings[i] = InstructionResult.NonBreakInstructionResult(permutation[i], 0);
                }

                int result = AmplificationCalculator.CalculateAmplification(cells, phaseSettings, initialInstructionResult);
                if (result > max)
                    max = result;

            }

            return max;
        }

        private static int[][] GetPermutations(int numberOfAmplifiers)
        {
            int[] initialPhaseSettings = new int[numberOfAmplifiers];
            for (int i = 0; i < numberOfAmplifiers; i++)
            {
                initialPhaseSettings[i] = i;
            }

            return PermutationsGenerator.Permutate(initialPhaseSettings);
        }
    }
}