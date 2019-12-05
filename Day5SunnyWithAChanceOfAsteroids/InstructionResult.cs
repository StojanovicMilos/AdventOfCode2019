using System;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class InstructionResult
    {
        public static InstructionResult Initial() => new InstructionResult(1, 0, false);
        public static InstructionResult NonBreakInstructionResult(int input, int output) => new InstructionResult(input, output, false);
        public static InstructionResult BreakInstructionResult(int input, int output) => new InstructionResult(input, output, true);

        private InstructionResult(int input, int output, bool isBreakInstruction)
        {
            Input = input;
            Output = output;
            IsBreakInstruction = isBreakInstruction;

            //if (output != 0)
            //    throw new Exception("this shouldn't happen until the end");

            Console.WriteLine(Output);
        }

        public int Input { get; }
        public int Output { get; }

        public bool IsBreakInstruction { get; }
    }
}