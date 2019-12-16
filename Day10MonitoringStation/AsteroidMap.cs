using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10MonitoringStation
{
    public class AsteroidMap
    {
        private readonly List<Asteroid> _map;

        public AsteroidMap(string input)
        {
            char[][] asteroids = input.Split(Environment.NewLine).Select(line => line.ToCharArray()).ToArray();
            _map = AsteroidMapInitializer.InitializeMap(asteroids);
        }

        private Asteroid GetBestStation() => _map.WithMaximum(GetNumberOfVisibleAsteroids);

        public string GetBestStationCoordinates() => GetBestStation().ToString();

        public int GetNumberOfVisibleAsteroids(Asteroid asteroid) => _map.Count(a => AsteroidsVisible(a, asteroid));

        private bool AsteroidsVisible(Asteroid asteroid1, Asteroid asteroid2)
        {
            if (asteroid1.X == asteroid2.X && asteroid1.Y == asteroid2.Y)
                return false;

            int totalDeltaX = Math.Abs(asteroid1.X - asteroid2.X);
            int totalDeltaY = Math.Abs(asteroid1.Y - asteroid2.Y);

            int greatestCommonDivisor = MyMath.GreatestCommonDivisor(totalDeltaX, totalDeltaY);

            int deltaX = totalDeltaX / greatestCommonDivisor;
            if (asteroid1.X > asteroid2.X)
                deltaX = -deltaX;

            int deltaY = totalDeltaY / greatestCommonDivisor;
            if (asteroid1.Y > asteroid2.Y)
                deltaY = -deltaY;

            for (int i = 1; i < greatestCommonDivisor; i++)
            {
                int x = asteroid1.X + deltaX * i;
                int y = asteroid1.Y + deltaY * i;
                if (_map.FirstOrDefault(a => a.X == x && a.Y == y) != null)
                    return false;
            }

            return true;
        }

        private int BiggestXCoordinate => _map.WithMaximum(a => Math.Abs(a.X)).X;
        private int BiggestYCoordinate => _map.WithMaximum(a => Math.Abs(a.Y)).Y;
        private int BiggestCoordinate => Math.Max(BiggestXCoordinate, BiggestYCoordinate);

        public IEnumerable<Asteroid> VaporizeAsteroids()
        {
            AngleHelper angleHelper = new AngleHelper(BiggestXCoordinate, BiggestYCoordinate);
            var station = GetBestStation();
            while (_map.Count > 1)
            {
                var nextAngle = angleHelper.GetNextAngle();
                if (TryGetAsteroidAtAngle(station, nextAngle, out var asteroid))
                {
                    _map.Remove(asteroid);
                    yield return asteroid;
                }
            }
        }

        private bool TryGetAsteroidAtAngle(Asteroid station, DeltaAngle nextAngle, out Asteroid asteroid)
        {
            for (int i = 1; i < BiggestCoordinate; i++)
            {
                int potentialAsteroidAtAngleX = station.X + nextAngle.Y * i;    //TODO rework??? explanation: coordinates in advent of code are vice versa, so angles have to be vice versa too... Just change X and Y value when generating angles...
                int potentialAsteroidAtAngleY = station.Y + nextAngle.X * i;

                Asteroid potentialAsteroidAtAngle = _map.FirstOrDefault(a => a.X == potentialAsteroidAtAngleX && a.Y == potentialAsteroidAtAngleY);

                if (potentialAsteroidAtAngle != null)
                {
                    asteroid = potentialAsteroidAtAngle;
                    return true;
                }
            }

            asteroid = null;
            return false;
        }
    }
}