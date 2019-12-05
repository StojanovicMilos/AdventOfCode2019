using System;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class EqualsInstruction : IInstruction
    {
        private readonly Memory _memory;
        private readonly int _firstOperand;
        private readonly int _secondOperand;
        private readonly int _thirdOperand;


        public EqualsInstruction(Memory memory, int firstOperand, int secondOperand, int thirdOperand)
        {
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
            _firstOperand = firstOperand;
            _secondOperand = secondOperand;
            _thirdOperand = thirdOperand;
        }

        public InstructionResult Execute(InstructionResult instructionResult)
        {
            _memory.SetCellAt(_thirdOperand, _firstOperand == _secondOperand ? 1 : 0);
            return instructionResult;
        }
    }
}