using System;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class Instructions
    {
        private readonly Memory _memory;

        public Instructions(Memory memory)
        {
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
        }

        public int Execute(InstructionResult instructionResult)
        {
            //int executedInstructions = 0;
            do
            {
                var nextInstruction = InstructionFactory.CreateInstruction(_memory);
                instructionResult = nextInstruction.Execute(instructionResult);
                //executedInstructions++;
                //Console.WriteLine("\n\nExecuted instruction" + executedInstructions);
                //Console.WriteLine(_memory.ToString());
                //Console.WriteLine();
            } while (!instructionResult.IsBreakInstruction);

            return instructionResult.Output;
        }
    }
}