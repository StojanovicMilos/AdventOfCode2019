using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4SecureContainer
{
    public interface IPasswordRule
    {
        bool IsValid(int password);
    }

    public class PasswordLength : IPasswordRule
    {
        public bool IsValid(int password) => password > 99999 && password < 1000000;
    }

    public class TwoAdjacentDigitsPart1 : IPasswordRule
    {
        public virtual bool IsValid(int password)
        {
            var digits = password.ToString().Select(p => p).ToArray();

            for (int i = 0; i < digits.Length - 1; i++)
            {
                if (digits[i] == digits[i + 1])
                    return true;
            }

            return false;
        }
    }

    public class TwoAdjacentDigitsPart2 : TwoAdjacentDigitsPart1
    {
        public override bool IsValid(int password) => password.ToString().GroupBy(x => x).Select(g => g.Count()).Any(c => c == 2);
    }

    public class NonDecreasingDigits : IPasswordRule
    {
        public bool IsValid(int password)
        {
            var digits = password.ToString().Select(digit => int.Parse(digit.ToString())).ToArray();

            for (int i = 0; i < digits.Length - 1; i++)
            {
                if (digits[i] > digits[i + 1])
                    return false;
            }

            return true;
        }
    }

    public class CompositePasswordRules : IPasswordRule
    {
        private readonly IEnumerable<IPasswordRule> _passwordRules;

        public static CompositePasswordRules DefaultRulesPart1() =>
            new CompositePasswordRules(new IPasswordRule[]
            {
                new PasswordLength(),
                new NonDecreasingDigits(),
                new TwoAdjacentDigitsPart1()
            });

        public static IPasswordRule DefaultRulesPart2() =>
            new CompositePasswordRules(new IPasswordRule[]
            {
                new PasswordLength(),
                new NonDecreasingDigits(),
                new TwoAdjacentDigitsPart2(),
            });

        public CompositePasswordRules(IEnumerable<IPasswordRule> passwordRules)
        {
            _passwordRules = passwordRules ?? throw new ArgumentNullException(nameof(passwordRules));
        }

        public bool IsValid(int password) => _passwordRules.All(p => p.IsValid(password));

        
    }

    public class DifferentCorrectPasswordCounter
    {
        private readonly IPasswordRule _passwordRule;

        public DifferentCorrectPasswordCounter(IPasswordRule passwordRule)
        {
            _passwordRule = passwordRule ?? throw new ArgumentNullException(nameof(passwordRule));
        }

        public int CountPasswordsIn(string range)
        {
            int minimum = Convert.ToInt32(range.Split('-')[0]);
            int maximum = Convert.ToInt32(range.Split('-')[1]);

            return Enumerable.Range(minimum, maximum - minimum + 1).Count(password => _passwordRule.IsValid(password));
        }
    }
}
