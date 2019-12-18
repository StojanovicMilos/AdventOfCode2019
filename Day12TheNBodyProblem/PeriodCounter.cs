using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Day10MonitoringStation;

namespace Day12TheNBodyProblem
{
    public class PeriodCounter
    {
        private readonly List<Coordinates> _positions;
        private readonly List<Coordinates> _velocities;

        private readonly HashSet<string> _x = new HashSet<string>();
        private int _xPeriod;

        private readonly HashSet<string> _y = new HashSet<string>();
        private int _yPeriod;

        private readonly HashSet<string> _z = new HashSet<string>();
        private int _zPeriod;

        public PeriodCounter(List<Coordinates> position, List<Coordinates> velocity)
        {
            _positions = position;
            _velocities = velocity;
            UpdatePeriod();
        }

        public bool AchievedPeriod() => _xPeriod > 0 && _yPeriod > 0 && _zPeriod > 0;

        public BigInteger Period() => MyMath.LeastCommonMultiplier(_xPeriod, _yPeriod, _zPeriod);

        public void UpdatePeriod()
        {
            string xKey = string.Join(',', _positions.Select(p => p.X)) + ',' + string.Join(',', _velocities.Select(v => v.X));
            if (_xPeriod == 0 && !_x.Contains(xKey))
                _x.Add(xKey);
            else
                _xPeriod = _x.Count;

            string yKey = string.Join(',', _positions.Select(p => p.Y)) + ',' + string.Join(',', _velocities.Select(v => v.Y));
            if (_yPeriod == 0 && !_y.Contains(yKey))
                _y.Add(yKey);
            else
                _yPeriod = _y.Count;

            string zKey = string.Join(',', _positions.Select(p => p.Z)) + ',' + string.Join(',', _velocities.Select(v => v.Z));
            if (_zPeriod == 0 && !_z.Contains(zKey))
                _z.Add(zKey);
            else
                _zPeriod = _z.Count;
        }
    }
}