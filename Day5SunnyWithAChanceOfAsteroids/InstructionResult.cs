using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class InstructionResult
    {
        public static InstructionResult NonBreakInstructionResult() => NonBreakInstructionResult(new List<BigInteger>(), new List<BigInteger>());
        public static InstructionResult NonBreakInstructionResult(BigInteger input) => NonBreakInstructionResult(new List<BigInteger> {input}, new List<BigInteger>());
        public static InstructionResult NonBreakInstructionResult(List<BigInteger> input) => NonBreakInstructionResult(input, new List<BigInteger>());
        public static InstructionResult NonBreakInstructionResult(List<BigInteger> input, List<BigInteger> output) => new InstructionResult(input, output, false, false);

        public static InstructionResult WaitingForInputInstructionResult(List<BigInteger> output) => new InstructionResult(new List<BigInteger>(), output, false, true);

        public static InstructionResult BreakInstructionResult(List<BigInteger> input, List<BigInteger> output) => new InstructionResult(input, output, true, false);

        private InstructionResult(List<BigInteger> input, List<BigInteger> output, bool isBreakInstruction, bool isWaitingForInput)
        {
            Inputs = input;
            Output = output;
            IsBreakInstruction = isBreakInstruction;
            IsWaitingForInput = isWaitingForInput;
        }

        public List<BigInteger> Inputs { get; }
        public List<BigInteger> Output { get; }

        public bool IsBreakInstruction { get; }

        public bool IsWaitingForInput { get; }

        public static InstructionResult JoinResults(InstructionResult phaseSetting, InstructionResult input) =>
            new InstructionResult(phaseSetting.Inputs.Concat(input.Inputs).ToList(), input.Output, input.IsBreakInstruction, input.IsWaitingForInput);

        
    }
}