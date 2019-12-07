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

        public InstructionResult Execute(InstructionResult instructionResult)
        {
            do
            {
                var nextInstruction = InstructionFactory.CreateInstruction(_memory);
                instructionResult = nextInstruction.Execute(instructionResult);
            } while (!instructionResult.IsBreakInstruction);

            return instructionResult;
        }
    }
}