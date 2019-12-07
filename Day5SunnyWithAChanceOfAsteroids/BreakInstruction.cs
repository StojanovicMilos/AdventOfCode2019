namespace Day5SunnyWithAChanceOfAsteroids
{
    public class BreakInstruction : IInstruction
    {
        public InstructionResult Execute(InstructionResult instructionResult) => InstructionResult.BreakInstructionResult(instructionResult.Inputs, instructionResult.Output);
    }
}