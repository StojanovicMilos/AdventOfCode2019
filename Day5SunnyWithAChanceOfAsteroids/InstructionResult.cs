using System.Collections.Generic;
using System.Linq;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class InstructionResult
    {
        public static InstructionResult Initial() => NonBreakInstructionResult(1, 0);

        public static InstructionResult NonBreakInstructionResult(int input, int output) => NonBreakInstructionResult(new List<int> {input}, output);
        public static InstructionResult NonBreakInstructionResult(List<int> input, int output) => new InstructionResult(input, output, false);

        public static InstructionResult BreakInstructionResult(List<int> input, int output) => new InstructionResult(input, output, true);

        private InstructionResult(List<int> input, int output, bool isBreakInstruction)
        {
            Inputs = input;
            Output = output;
            IsBreakInstruction = isBreakInstruction;
            //Console.WriteLine(Output);
        }

        public List<int> Inputs { get; }
        public int Output { get; }

        public bool IsBreakInstruction { get; }

        public static InstructionResult JoinResults(InstructionResult phaseSetting, InstructionResult input) => 
            new InstructionResult(phaseSetting.Inputs.Concat(input.Inputs).ToList(), input.Output, input.IsBreakInstruction);
    }
}