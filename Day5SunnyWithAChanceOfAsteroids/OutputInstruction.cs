using System;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class OutputInstruction : IInstruction
    {
        private readonly Memory _memory;
        private readonly int _firstOperand;

        public OutputInstruction(Memory memory, int firstOperand)
        {
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
            _firstOperand = firstOperand;
        }

        public InstructionResult Execute(InstructionResult instructionResult) => InstructionResult.NonBreakInstructionResult(instructionResult.Inputs, _memory.GetCellAt(_firstOperand));
    }
}