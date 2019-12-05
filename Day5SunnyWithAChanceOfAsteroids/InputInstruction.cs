using System;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class InputInstruction : IInstruction
    {
        private readonly Memory _memory;
        private readonly int _firstOperand;
        

        public InputInstruction(Memory memory, int firstOperand)
        {
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
            _firstOperand = firstOperand;
        }

        public InstructionResult Execute(InstructionResult instructionResult)
        {
            _memory.SetCellAt(_firstOperand, instructionResult.Input);
            return InstructionResult.NonBreakInstructionResult(0, instructionResult.Output);
        }
    }
}