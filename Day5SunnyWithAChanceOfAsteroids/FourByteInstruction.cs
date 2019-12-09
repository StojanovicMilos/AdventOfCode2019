using System;
using System.Numerics;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class FourByteInstruction : IInstruction
    {
        private readonly Memory _memory;
        private readonly BigInteger _firstOperand;
        private readonly BigInteger _secondOperand;
        private readonly BigInteger _thirdOperand;
        private readonly Action<Memory, BigInteger, BigInteger> _saveResult;
        private readonly Func<BigInteger, BigInteger, BigInteger> _operation;

        public FourByteInstruction(Memory memory, BigInteger firstOperand, BigInteger secondOperand, BigInteger thirdOperand, Action<Memory, BigInteger, BigInteger> saveResult, Func<BigInteger, BigInteger, BigInteger> operation)
        {
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