using System;
using System.Linq;

namespace Day10MonitoringStation
{
    public class AsteroidMap
    {
        private readonly Asteroid[] _map;

        public AsteroidMap(string input)
        {
            char[][] asteroids = input.Split(Environment.NewLine).Select(line => line.ToCharArray()).ToArray();
            _map = AsteroidMapInitializer.InitializeMap(asteroids);
        }

        public string GetBestStationCoordinates() => _map.WithMaximum(GetNumberOfVisibleAsteroids).ToString();

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
    }
}