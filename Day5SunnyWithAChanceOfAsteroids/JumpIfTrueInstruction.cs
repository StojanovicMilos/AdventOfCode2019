using System;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class JumpIfTrueInstruction : IInstruction
    {
        private readonly Memory _memory;
        private readonly int _firstOperand;
        private readonly int _secondOperand;


        public JumpIfTrueInstruction(Memory memory, int firstOperand, int secondOperand)
        {
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
            _firstOperand = firstOperand;
            _secondOperand = secondOperand;
        }

        public InstructionResult Execute(InstructionResult instructionResult)
        {
            if (_firstOperand != 0)
                _memory.SetCurrentCellIndex(_secondOperand);
            return instructionResult;
        }
    }
}