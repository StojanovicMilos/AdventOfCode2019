using System;
using System.Numerics;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class AdjustRelativeBaseInstruction : IInstruction
    {
        private readonly Memory _memory;
        private readonly BigInteger _firstOperand;

        public AdjustRelativeBaseInstruction(Memory memory, BigInteger firstOperand)
        {
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
            _firstOperand = firstOperand;
        }

        public InstructionResult Execute(InstructionResult instructionResult)
        {
            _memory.AdjustRelativeBase(_firstOperand);
            return instructionResult;
        }
    }
}