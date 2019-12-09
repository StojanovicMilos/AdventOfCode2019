using System;
using System.Linq;
using System.Numerics;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class InputInstruction : IInstruction
    {
        private readonly Memory _memory;
        private readonly BigInteger _firstOperand;
        private readonly Action<Memory, BigInteger, BigInteger> _saveResult;

        public InputInstruction(Memory memory, BigInteger firstOperand, Action<Memory, BigInteger, BigInteger> saveResult)
        {
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
            _firstOperand = firstOperand;
            _saveResult = saveResult;
        }

        public InstructionResult Execute(InstructionResult instructionResult)
        {
            if (instructionResult.Inputs.Any())
            {
                _saveResult(_memory, _firstOperand, instructionResult.Inputs.First());
                return InstructionResult.NonBreakInstructionResult(instructionResult.Inputs.Skip(1).ToList(), instructionResult.Output);
            }
            _memory.SetCurrentCellIndexRelative(-2);
            return InstructionResult.WaitingForInputInstructionResult(instructionResult.Output);
        }
    }
}