using System;
using System.Numerics;
using Day5SunnyWithAChanceOfAsteroids;

namespace Day7AmplificationCircuit
{
    public static class AmplificationCalculator
    {
        public static InstructionResult CalculateAmplification(BigInteger[] cells, InstructionResult[] phaseSettings, InstructionResult initialInstruction)
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
            initialInstruction = InstructionResult.NonBreakInstructionResult(output.Output);

            while (!output.IsBreakInstruction)
            {
                output = amplifiers.AmplifyWithoutPhaseSettings(initialInstruction);
                initialInstruction = InstructionResult.NonBreakInstructionResult(output.Output);
            }

            return output;
        }

        private static BigInteger[] CopyCells(BigInteger[] cells)
        {
            BigInteger[] memoryCells = new BigInteger[cells.Length];
            Array.Copy(cells, memoryCells, cells.Length);
            return memoryCells;
        }
    }
}