using System;
using System.Linq;

namespace Day12TheNBodyProblem
{
    public class Moons
    {
        private readonly Moon[] _moons;

        public Moons(Moon[] moons)
        {
            _moons = moons ?? throw new ArgumentNullException(nameof(moons));
        }

        public void PerformSteps(int numberOfSteps)
        {
            for (int i = 0; i < numberOfSteps; i++)
            {
                PerformStep();
            }
        }

        private void PerformStep()
        {
            foreach (var moon in _moons)
            {
                moon.UpdateVelocity(_moons);
            }

            foreach (var moon in _moons)
            {
                moon.UpdatePosition();
            }
        }

        public int TotalEnergy() => _moons.Sum(m => m.TotalEnergy);

        public override string ToString() => string.Join(Environment.NewLine, _moons.Select(m => m.ToString()));
    }
}