using System;

namespace Day12TheNBodyProblem
{
    public class Moon
    {
        private readonly Coordinates _position;
        private readonly Coordinates _velocity;

        public Moon(Coordinates position)
        {
            _position = position ?? throw new ArgumentNullException(nameof(position));
            _velocity = new Coordinates(0, 0, 0);
        }

        private int PotentialEnergy => _position.Energy;
        private int KineticEnergy => _velocity.Energy;
        public int TotalEnergy => PotentialEnergy * KineticEnergy;

        public void UpdateVelocity(Moon[] otherMoons)
        {
            foreach (var otherMoon in otherMoons)
            {
                UpdateVelocity(otherMoon._position);
            }
        }

        private void UpdateVelocity(Coordinates otherMoonPosition)
        {
            if (otherMoonPosition.X > _position.X)
            {
                _velocity.X++;
            }
            else if (otherMoonPosition.X < _position.X)
            {
                _velocity.X--;
            }

            if (otherMoonPosition.Y > _position.Y)
            {
                _velocity.Y++;
            }
            else if (otherMoonPosition.Y < _position.Y)
            {
                _velocity.Y--;
            }

            if (otherMoonPosition.Z > _position.Z)
            {
                _velocity.Z++;
            }
            else if (otherMoonPosition.Z < _position.Z)
            {
                _velocity.Z--;
            }
        }

        public void UpdatePosition()
        {
            _position.X += _velocity.X;
            _position.Y += _velocity.Y;
            _position.Z += _velocity.Z;
        }

        public override string ToString() => $"pos={_position}, vel={_velocity}";
    }
}