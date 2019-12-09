using System;
using System.Numerics;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class LessThanInstruction : IInstruction
    {
        private readonly Memory _memory;
        private readonly BigInteger _firstOperand;
        private readonly BigInteger _secondOperand;
        private readonly BigInteger _thirdOperand;
        private readonly Action<Memory, BigInteger, BigInteger> _saveResult;

        public LessThanInstruction(Memory memory, BigInteger firstOperand, BigInteger secondOperand, BigInteger thirdOperand, Action<Memory, BigInteger, BigInteger> saveResult)
        {
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
            _firstOperand = firstOperand;
            _secondOperand = secondOperand;
            _thirdOperand = thirdOperand;
            _saveResult = saveResult;
        }

        public InstructionResult Execute(InstructionResult instructionResult)
        {
            _saveResult(_memory, _thirdOperand, _firstOperand < _secondOperand ? 1 : 0);
            return instructionResult;
        }
    }
}