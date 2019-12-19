using System;
using System.Numerics;
using Day5SunnyWithAChanceOfAsteroids;

namespace Day13CarePackage
{
    public class ArcadeCabinet
    {
        private readonly Instructions _instructions;
        private readonly Screen _screen = new Screen();
        public BigInteger Score { get; private set; }

        public ArcadeCabinet(Instructions instructions)
        {
            _instructions = instructions ?? throw new ArgumentNullException(nameof(instructions));
            UpdateState(InstructionResult.NonBreakInstructionResult());
        }

        public void Play()
        {
            while (_screen.GetNumberOfBlockTiles() > 0)
            {
                UpdateState(CalculateJoystickPosition());
            }
        }

        private InstructionResult CalculateJoystickPosition()
        {
            BigInteger ballPosition = _screen.GetBallPosition();
            BigInteger paddlePosition = _screen.GetPaddlePosition();

            if (ballPosition < paddlePosition)
                return InstructionResult.NonBreakInstructionResult(-1);
            if (ballPosition == paddlePosition)
                return InstructionResult.NonBreakInstructionResult(0);
            return InstructionResult.NonBreakInstructionResult(1);
        }

        private void UpdateState(InstructionResult instructionResult)
        {
            instructionResult = _instructions.Execute(instructionResult);

            foreach (var tileConfiguration in instructionResult.Output.SplitList(3))
            {
                BigInteger x = tileConfiguration[0];
                BigInteger y = tileConfiguration[1];

                if (x == -1 && y == 0)
                {
                    Score = tileConfiguration[2];
                }
                else
                {
                    Tile tile = (Tile) (int) tileConfiguration[2];
                    _screen.Set(x, y, tile);
                }
            }
        }

        public int GetNumberOfBlockTiles() => _screen.GetNumberOfBlockTiles();
    }
}