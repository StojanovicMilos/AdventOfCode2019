using System;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class FourByteInstruction : IInstruction
    {
        private readonly Memory _memory;
        private readonly int _firstOperand;
        private readonly int _secondOperand;
        private readonly int _thirdOperand;
        private readonly Action<Memory, int, int> _saveResult;
        private readonly Func<int, int, int> _operation;

        public FourByteInstruction(Memory memory, int firstOperand, int secondOperand, int thirdOperand, Action<Memory, int, int> saveResult, Func<int, int, int> operation)
        {
            if (thirdOperand < 0) throw new ArgumentOutOfRangeException(nameof(thirdOperand));
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
            _firstOperand = firstOperand;
            _secondOperand = secondOperand;
            _thirdOperand = thirdOperand;
            _saveResult = saveResult ?? throw new ArgumentNullException(nameof(saveResult));
            _operation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public InstructionResult Execute(InstructionResult instructionResult)
        {
            _saveResult(_memory, _thirdOperand, _operation(_firstOperand, _secondOperand));
            return instructionResult;
        }
    }
}