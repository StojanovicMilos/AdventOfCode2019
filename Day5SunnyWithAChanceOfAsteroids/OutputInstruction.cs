using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class OutputInstruction : IInstruction
    {        private readonly BigInteger _firstOperand;

        public OutputInstruction(BigInteger firstOperand)
        {
            _firstOperand = firstOperand;
        }

        public InstructionResult Execute(InstructionResult instructionResult)
        {
            return InstructionResult.NonBreakInstructionResult(instructionResult.Inputs, instructionResult.Output.Concat(new List<BigInteger> {_firstOperand}).ToList());
        }
    }
}