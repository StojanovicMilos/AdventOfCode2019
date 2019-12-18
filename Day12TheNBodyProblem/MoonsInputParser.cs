using System;
using System.Linq;

namespace Day12TheNBodyProblem
{
    public static class MoonsInputParser
    {
        public static Moon[] Parse(string input)
        {
            var lines = input.Split(Environment.NewLine);

            Moon[] moons = new Moon[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var data = line.Split(',').Select(d => Convert.ToInt32(d)).ToArray();

                moons[i] = new Moon(new Coordinates(data[0], data[1], data[2]));
            }

            return moons;
        }
    }
}