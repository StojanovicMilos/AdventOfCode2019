using System;
using Day5SunnyWithAChanceOfAsteroids;

namespace Day7AmplificationCircuit
{
    public class Amplifiers
    {
        private readonly Instructions[] _instructions;
        private readonly InstructionResult[] _phaseSettings;

        public Amplifiers(Instructions[] instructions, InstructionResult[] phaseSettings)
        {
            _instructions = instructions ?? throw new ArgumentNullException(nameof(instructions));
            _phaseSettings = phaseSettings ?? throw new ArgumentNullException(nameof(phaseSettings));
            if (instructions.Length != phaseSettings.Length) throw new ArgumentException(nameof(instructions) + " has to have the same number of elements as " + nameof(phaseSettings));
            if (instructions.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(instructions));
            if (phaseSettings.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(phaseSettings));
        }

        public InstructionResult Amplify(InstructionResult input)
        {
            InstructionResult output = null;
            for (int i = 0; i < _instructions.Length; i++)
            {
                output = _instructions[i].Execute(InstructionResult.JoinResults(_phaseSettings[i], input));
                input = InstructionResult.NonBreakInstructionResult(output.Output, 0);
            }

            return output;
        }
    }
}