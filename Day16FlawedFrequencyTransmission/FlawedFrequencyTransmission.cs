using System;
using System.Linq;

namespace Day16FlawedFrequencyTransmission
{
    public class FlawedFrequencyTransmission
    {
        private readonly IBasePatternGenerator _basePatternGenerator;

        public FlawedFrequencyTransmission(IBasePatternGenerator basePatternGenerator)
        {
            _basePatternGenerator = basePatternGenerator ?? throw new ArgumentNullException(nameof(basePatternGenerator));
        }

        public string CalculateOutputSignalFor(string input, int numberOfPhases)
        {
            if (numberOfPhases <= 0) throw new ArgumentOutOfRangeException(nameof(numberOfPhases));
            int[] digits = input.Select(c => int.Parse(c.ToString())).ToArray();

            string returnValue = string.Empty;

            for (int phase = 0; phase < numberOfPhases; phase++)
            {
                returnValue = string.Empty;
                for (int elementNumber = 0; elementNumber < digits.Length; elementNumber++)
                {
                    returnValue += (Math.Abs(digits.Zip(_basePatternGenerator.GetBasePatternFor(elementNumber), (a, b) => a * b).Sum()) % 10).ToString();
                }

                digits = returnValue.Select(c => int.Parse(c.ToString())).ToArray();
            }

            return returnValue;
        }

        public string CalculatePartTwoOutputSignalFor(string input, int numberOfPhases)
        {
            input = string.Join("", Enumerable.Repeat(input, 10000));

            string result = CalculateOutputSignalFor(input, numberOfPhases);

            int offset = Convert.ToInt32(input.Substring(0, 7));

            return result.Substring(offset, 8);
        }
    }
}