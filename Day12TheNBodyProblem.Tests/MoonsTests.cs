using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Day12TheNBodyProblem.Tests
{
    public class MoonsTests
    {
        [Theory]
        [ClassData(typeof(MoonsStateTestData))]
        public void MoonsStateWorks(string input, int numberOfSteps, string expectedState)
        {
            //Arrange
            Moons moons = new Moons(MoonsInputParser.Parse(input));

            //Act
            moons.PerformSteps(numberOfSteps);
            var actualState = moons.ToString();

            //Assert
            Assert.Equal(expectedState.RemoveWhitespace(), actualState.RemoveWhitespace());
        }

        [Theory]
        [ClassData(typeof(MoonsEnergyTestData))]
        public void MoonsTotalEnergyWorks(string input, int numberOfSteps, int expectedTotalEnergy)
        {
            //Arrange
            Moons moons = new Moons(MoonsInputParser.Parse(input));

            //Act
            moons.PerformSteps(numberOfSteps);
            var actualTotalEnergy = moons.TotalEnergy();

            //Assert
            Assert.Equal(expectedTotalEnergy, actualTotalEnergy);
        }
    }

    public class MoonsStateTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                TestDataConstants.Input1,
                0,
                @"pos=<x= -1, y=  0, z=  2>, vel=<x=  0, y=  0, z=  0>
pos=<x=  2, y=-10, z= -7>, vel=<x=  0, y=  0, z=  0>
pos=<x=  4, y= -8, z=  8>, vel=<x=  0, y=  0, z=  0>
pos=<x=  3, y=  5, z= -1>, vel=<x=  0, y=  0, z=  0>"
            };

            yield return new object[]
            {
                TestDataConstants.Input1,
                1,
                @"pos=<x= 2, y=-1, z= 1>, vel=<x= 3, y=-1, z=-1>
pos=<x= 3, y=-7, z=-4>, vel=<x= 1, y= 3, z= 3>
pos=<x= 1, y=-7, z= 5>, vel=<x=-3, y= 1, z=-3>
pos=<x= 2, y= 2, z= 0>, vel=<x=-1, y=-3, z= 1>"
            };

            yield return new object[]
            {
                TestDataConstants.Input1,
                2,
                @"pos=<x= 5, y=-3, z=-1>, vel=<x= 3, y=-2, z=-2>
pos=<x= 1, y=-2, z= 2>, vel=<x=-2, y= 5, z= 6>
pos=<x= 1, y=-4, z=-1>, vel=<x= 0, y= 3, z=-6>
pos=<x= 1, y=-4, z= 2>, vel=<x=-1, y=-6, z= 2>"
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }


    public class MoonsEnergyTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                TestDataConstants.Input1,
                10,
                179
            };

            yield return new object[]
            {
                TestDataConstants.Input2,
                100,
                1940
            };

            yield return new object[]
            {
                TestDataConstants.Input3,
                1000,
                9958
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public static class TestDataConstants
    {
        public const string Input1 = @"-1,0,2
2,-10,-7
4,-8,8
3,5,-1";

        public const string Input2 = @"-8,-10,0
5,5,10
2,-7,3
9,-8,-3";

        public const string Input3 = @"7,10,17
-2,7,0
12,5,12
5,-8,6";
    }

}
