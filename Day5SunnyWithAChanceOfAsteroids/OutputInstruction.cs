using System;
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
            Console.WriteLine("Output = " + _firstOperand);
            return InstructionResult.NonBreakInstructionResult(instructionResult.Inputs, _firstOperand);
        }
    }
}