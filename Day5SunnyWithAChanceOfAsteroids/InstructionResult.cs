using System.Collections.Generic;
using System.Linq;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class InstructionResult
    {
        public static InstructionResult Initial() => NonBreakInstructionResult(1, 0);

        public static InstructionResult NonBreakInstructionResult(int input, int output) => NonBreakInstructionResult(new List<int> {input}, output);
        public static InstructionResult NonBreakInstructionResult(List<int> input, int output) => new InstructionResult(input, output, false, false);

        public static InstructionResult WaitingForInputInstructionResult(int output) => new InstructionResult(new List<int>(), output, false, true);

        public static InstructionResult BreakInstructionResult(List<int> input, int output) => new InstructionResult(input, output, true, false);

        private InstructionResult(List<int> input, int output, bool isBreakInstruction, bool isWaitingForInput)
        {
            Inputs = input;
            Output = output;
            IsBreakInstruction = isBreakInstruction;
            IsWaitingForInput = isWaitingForInput;
        }

        public List<int> Inputs { get; }
        public int Output { get; }

        public bool IsBreakInstruction { get; }

        public bool IsWaitingForInput { get; }

        public static InstructionResult JoinResults(InstructionResult phaseSetting, InstructionResult input) =>
            new InstructionResult(phaseSetting.Inputs.Concat(input.Inputs).ToList(), input.Output, input.IsBreakInstruction, input.IsWaitingForInput);
    }
}