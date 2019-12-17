using System;
using System.Linq;
using Day11SpacePolice.Day11SpacePolice;
using Day5SunnyWithAChanceOfAsteroids;

namespace Day11SpacePolice
{
    public class Robot
    {
        private readonly Instructions _instructions;
        private readonly Color _startColor;

        public Robot(Instructions instructions, Color startColor)
        {
            _instructions = instructions;
            _startColor = startColor;
        }

        public int GetNumberOfPaintedPanels() => PaintPanels().NumberOfPanels;

        public string PaintAndDisplay() => PaintPanels().Display();

        private Panels PaintPanels()
        {
            Panels panels = new Panels();

            InstructionResult instructionResult = InstructionResult.NonBreakInstructionResult((int) _startColor);

            do
            {
                instructionResult = _instructions.Execute(instructionResult);
                if (instructionResult.IsWaitingForInput)
                {
                    Color color = (Color) (int) instructionResult.Output.First();
                    TurningDirection turningDirection = (TurningDirection) (int) instructionResult.Output.Skip(1).First();

                    panels.PaintAndMove(color, turningDirection);

                    instructionResult = InstructionResult.JoinResults(instructionResult, InstructionResult.NonBreakInstructionResult(Convert.ToInt32(panels.GetCurrentPanelColor()))); //???
                }
            } while (!instructionResult.IsBreakInstruction);

            return panels;
        }
    }
}