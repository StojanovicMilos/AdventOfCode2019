using System;
using Day5SunnyWithAChanceOfAsteroids;

namespace Day7AmplificationCircuit
{
    public static class AmplificationCalculator
    {
        public static InstructionResult CalculateAmplification(int[] cells, InstructionResult[] phaseSettings, InstructionResult initialInstruction)
        {
            int numberOfAmplifiers = phaseSettings.Length;

            Instructions[] instructions = new Instructions[numberOfAmplifiers];
            for (int i = 0; i < numberOfAmplifiers; i++)
            {
                Memory memory = new Memory(CopyCells(cells));
                instructions[i] = new Instructions(memory);
            }

            Amplifiers amplifiers = new Amplifiers(instructions, phaseSettings);

            var output = amplifiers.Amplify(initialInstruction);
            initialInstruction = InstructionResult.NonBreakInstructionResult(output.Output, 0);

            while (!output.IsBreakInstruction)
            {
                output = amplifiers.AmplifyWithoutPhaseSettings(initialInstruction);
                initialInstruction = InstructionResult.NonBreakInstructionResult(output.Output, 0);
            }

            return output;
        }

        private static int[] CopyCells(int[] cells)
        {
            int[] memoryCells = new int[cells.Length];
            Array.Copy(cells, memoryCells, cells.Length);
            return memoryCells;
        }
    }
}