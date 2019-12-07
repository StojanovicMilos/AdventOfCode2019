using System;
using System.Linq;

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
            _memory.SetCellAt(_firstOperand, instructionResult.Inputs.First());
            return InstructionResult.NonBreakInstructionResult(instructionResult.Inputs.Skip(1).ToList(), instructionResult.Output);
        }
    }
}