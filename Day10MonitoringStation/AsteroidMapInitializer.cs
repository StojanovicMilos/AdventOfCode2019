using System.Collections.Generic;

namespace Day10MonitoringStation
{
    public static class AsteroidMapInitializer
    {
        public static List<Asteroid> InitializeMap(char[][] asteroids)
        {
            List<Asteroid> map = new List<Asteroid>();

            for (int i = 0; i < asteroids.Length; i++)
            {
                for (int j = 0; j < asteroids[0].Length; j++)
                {
                    if (asteroids[i][j] == '#')
                    {
                        map.Add(new Asteroid(i, j));
                    }
                }
            }

            return map;
        }
    }
}