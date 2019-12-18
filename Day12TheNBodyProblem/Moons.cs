using System;
using System.Linq;
using System.Numerics;

namespace Day12TheNBodyProblem
{
    public class Moons
    {
        private readonly Moon[] _moons;
        private readonly PeriodCounter _periodCounter;

        public Moons(Moon[] moons)
        {
            _moons = moons ?? throw new ArgumentNullException(nameof(moons));
            _periodCounter = new PeriodCounter(_moons.Select(m => m.Position).ToList(), _moons.Select(m => m.Velocity).ToList());
        }

        public void PerformSteps(int numberOfSteps)
        {
            for (int i = 0; i < numberOfSteps; i++)
            {
                PerformStep();
            }
        }

        public BigInteger GetNumberOfStepsNeededForStillState()
        {
            while (!_periodCounter.AchievedPeriod())
            {
                PerformStep();
                UpdatePeriod();
            }

            return _periodCounter.Period();
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

        private void UpdatePeriod() => _periodCounter.UpdatePeriod();

        public int TotalEnergy() => _moons.Sum(m => m.TotalEnergy);

        public string GetState() => string.Join(Environment.NewLine, _moons.Select(m => m.GetState()));
    }
}