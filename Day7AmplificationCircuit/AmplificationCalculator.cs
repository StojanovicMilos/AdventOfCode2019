using System;
using Day5SunnyWithAChanceOfAsteroids;

namespace Day7AmplificationCircuit
{
    public static class AmplificationCalculator
    {
        public static int CalculateAmplification(int[] cells, InstructionResult[] phaseSettings, InstructionResult initialInstruction)
        {
            int numberOfAmplifiers = phaseSettings.Length;

            Instructions[] instructions = new Instructions[numberOfAmplifiers];
            for (int i = 0; i < numberOfAmplifiers; i++)
            {
                Memory memory = new Memory(CopyCells(cells));
                instructions[i] = new Instructions(memory);
            }

            Amplifiers amplifiers = new Amplifiers(instructions, phaseSettings);

            return amplifiers.Amplify(initialInstruction).Output;
        }

        private static int[] CopyCells(int[] cells)
        {
            int[] memoryCells = new int[cells.Length];
            Array.Copy(cells, memoryCells, cells.Length);
            return memoryCells;
        }
    }
}