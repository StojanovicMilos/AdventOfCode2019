using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class InstructionResult
    {
        public static InstructionResult Initial() => NonBreakInstructionResult(1, 0);

        public static InstructionResult NonBreakInstructionResult(BigInteger input, BigInteger output) => NonBreakInstructionResult(new List<BigInteger> {input}, output);
        public static InstructionResult NonBreakInstructionResult(List<BigInteger> input, BigInteger output) => new InstructionResult(input, output, false, false);

        public static InstructionResult WaitingForInputInstructionResult(BigInteger output) => new InstructionResult(new List<BigInteger>(), output, false, true);

        public static InstructionResult BreakInstructionResult(List<BigInteger> input, BigInteger output) => new InstructionResult(input, output, true, false);

        private InstructionResult(List<BigInteger> input, BigInteger output, bool isBreakInstruction, bool isWaitingForInput)
        {
            Inputs = input;
            Output = output;
            IsBreakInstruction = isBreakInstruction;
            IsWaitingForInput = isWaitingForInput;
        }

        public List<BigInteger> Inputs { get; }
        public BigInteger Output { get; }

        public bool IsBreakInstruction { get; }

        public bool IsWaitingForInput { get; }

        public static InstructionResult JoinResults(InstructionResult phaseSetting, InstructionResult input) =>
            new InstructionResult(phaseSetting.Inputs.Concat(input.Inputs).ToList(), input.Output, input.IsBreakInstruction, input.IsWaitingForInput);
    }
}