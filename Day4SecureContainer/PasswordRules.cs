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

    public class TwoAdjacentDigits : IPasswordRule
    {
        public bool IsValid(int password)
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

        public static CompositePasswordRules DefaultRules() =>
            new CompositePasswordRules(new IPasswordRule[]
            {
                new PasswordLength(),
                new TwoAdjacentDigits(),
                new NonDecreasingDigits()
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
