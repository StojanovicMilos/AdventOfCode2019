using Day5SunnyWithAChanceOfAsteroids;

namespace Day7AmplificationCircuit
{
    public static class MaxAmplificationCalculator
    {
        public static int CalculateMaxAmplification(int phaseSettingsMin, int phaseSettingsMax, int[] cells, InstructionResult initialInstructionResult)
        {
            int maxAmplification = int.MinValue;
            int numberOfAmplifiers = phaseSettingsMax - phaseSettingsMin + 1;
            foreach (var permutation in GetPermutations(phaseSettingsMin, numberOfAmplifiers))
            {
                InstructionResult[] phaseSettings = new InstructionResult[numberOfAmplifiers];
                for (int i = 0; i < phaseSettings.Length; i++)
                {
                    phaseSettings[i] = InstructionResult.NonBreakInstructionResult(permutation[i], 0);
                }

                int result = AmplificationCalculator.CalculateAmplification(cells, phaseSettings, initialInstructionResult).Output;
                if (result > maxAmplification)
                    maxAmplification = result;
            }

            return maxAmplification;
        }

        private static int[][] GetPermutations(int phaseSettingsMin, int numberOfAmplifiers)
        {
            int[] initialPhaseSettings = new int[numberOfAmplifiers];
            for (int i = 0; i < numberOfAmplifiers; i++)
            {
                initialPhaseSettings[i] = phaseSettingsMin + numberOfAmplifiers - 1 - i;
            }

            return PermutationsGenerator.Permutate(initialPhaseSettings);
        }
    }
}