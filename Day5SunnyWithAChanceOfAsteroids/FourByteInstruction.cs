using System;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class FourByteInstruction : IInstruction
    {
        private readonly Memory _memory;
        private readonly int _firstOperand;
        private readonly int _secondOperand;
        private readonly int _resultAddress;
        private readonly Action<Memory, int, int> _saveResult;
        private readonly Func<int, int, int> _operation;

        public FourByteInstruction(Memory memory, int firstOperand, int secondOperand, int resultAddress, Action<Memory, int, int> saveResult, Func<int, int, int> operation)
        {
            if (resultAddress < 0) throw new ArgumentOutOfRangeException(nameof(resultAddress));
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
            _firstOperand = firstOperand;
            _secondOperand = secondOperand;
            _resultAddress = resultAddress;
            _saveResult = saveResult ?? throw new ArgumentNullException(nameof(saveResult));
            _operation = operation ?? throw new ArgumentNullException(nameof(operation));
        }

        public InstructionResult Execute(InstructionResult instructionResult)
        {
            _saveResult(_memory, _resultAddress, _operation(_firstOperand, _secondOperand));
            return instructionResult;
        }
    }
}