using System;

namespace Day12TheNBodyProblem
{
    public class Moon
    {
        public Coordinates Position { get; }
        public Coordinates Velocity { get; }

        public Moon(Coordinates position)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));

            Velocity = new Coordinates(0, 0, 0);
        }

        public int TotalEnergy => Position.Energy * Velocity.Energy;

        public void UpdateVelocity(Moon[] otherMoons)
        {
            foreach (var otherMoon in otherMoons)
            {
                UpdateVelocity(otherMoon.Position);
            }
        }

        private void UpdateVelocity(Coordinates otherMoonPosition)
        {
            Velocity.X += Math.Sign(otherMoonPosition.X - Position.X);
            Velocity.Y += Math.Sign(otherMoonPosition.Y - Position.Y);
            Velocity.Z += Math.Sign(otherMoonPosition.Z - Position.Z);
        }

        public void UpdatePosition()
        {
            Position.X += Velocity.X;
            Position.Y += Velocity.Y;
            Position.Z += Velocity.Z;
        }

        public string GetState() => $"pos={Position.GetState()}, vel={Velocity.GetState()}";
    }
}