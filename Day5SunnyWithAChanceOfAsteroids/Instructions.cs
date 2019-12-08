using System;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public class Instructions
    {
        private readonly Memory _memory;

        public Instructions(Memory memory)
        {
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
            IsFinished = false;
        }

        public InstructionResult Execute(InstructionResult instructionResult)
        {
            //int i = 0;
            do
            {
                var nextInstruction = InstructionFactory.CreateInstruction(_memory);
                //Console.WriteLine("Executing instruction " + i++);
                instructionResult = nextInstruction.Execute(instructionResult);
            } while (!instructionResult.IsBreakInstruction && !instructionResult.IsWaitingForInput);

            if (instructionResult.IsBreakInstruction)
                IsFinished = true;

            return instructionResult;
        }

        public bool IsFinished { get; private set; }
    }
}