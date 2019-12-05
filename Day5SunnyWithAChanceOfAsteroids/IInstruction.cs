namespace Day5SunnyWithAChanceOfAsteroids
{
    public interface IInstruction
    {
        InstructionResult Execute(InstructionResult instructionResult);
    }
}