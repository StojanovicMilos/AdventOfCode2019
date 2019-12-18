using System.Numerics;

namespace Day10MonitoringStation
{
    public static class MyMath
    {
        public static int GreatestCommonDivisor(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }

        private static BigInteger GreatestCommonDivisor(BigInteger a, BigInteger b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }

        public static BigInteger LeastCommonMultiplier(BigInteger a, BigInteger b) => a * b / GreatestCommonDivisor(a, b);

        public static BigInteger LeastCommonMultiplier(BigInteger a, BigInteger b, BigInteger c) => LeastCommonMultiplier(LeastCommonMultiplier(a, b), c);
    }
}