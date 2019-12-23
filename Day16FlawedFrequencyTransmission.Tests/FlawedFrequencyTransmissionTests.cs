using Xunit;

namespace Day16FlawedFrequencyTransmission.Tests
{
    public class FlawedFrequencyTransmissionTests
    {
        [Theory]
        [InlineData("12345678", 1, "48226158")]
        [InlineData("12345678", 2, "34040438")]
        [InlineData("12345678", 3, "03415518")]
        [InlineData("12345678", 4, "01029498")]
        [InlineData("80871224585914546619083218645595", 100, "24176176")]
        [InlineData("19617804207202209144916044189917", 100, "73745418")]
        [InlineData("69317163492948606335995924319873", 100, "52432133")]
        [InlineData("59704176224151213770484189932636989396016853707543672704688031159981571127975101449262562108536062222616286393177775420275833561490214618092338108958319534766917790598728831388012618201701341130599267905059417956666371111749252733037090364984971914108277005170417001289652084308389839318318592713462923155468396822247189750655575623017333088246364350280299985979331660143758996484413769438651303748536351772868104792161361952505811489060546839032499706132682563962136170941039904873411038529684473891392104152677551989278815089949043159200373061921992851799948057507078358356630228490883482290389217471790233756775862302710944760078623023456856105493"
            , 100, "28430146")]
        public void FlawedFrequencyTransmissionWorks(string input, int numberOfPhases, string expectedOutput)
        {
            //Arrange
            IBasePatternGenerator basePatternGenerator = new BasePatternGenerator();
            FlawedFrequencyTransmission flawedFrequencyTransmission = new FlawedFrequencyTransmission(basePatternGenerator);

            //Act
            string actualOutput = flawedFrequencyTransmission.CalculateOutputSignalFor(input, numberOfPhases).Substring(0, 8);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        //[Theory]
        //[InlineData("03036732577212944063491565474664", 100, "84462026")]
        //[InlineData("02935109699940807407585447034323", 100, "78725270")]
        //[InlineData("03081770884921959731165446850517", 100, "53553731")]
        //[InlineData("59704176224151213770484189932636989396016853707543672704688031159981571127975101449262562108536062222616286393177775420275833561490214618092338108958319534766917790598728831388012618201701341130599267905059417956666371111749252733037090364984971914108277005170417001289652084308389839318318592713462923155468396822247189750655575623017333088246364350280299985979331660143758996484413769438651303748536351772868104792161361952505811489060546839032499706132682563962136170941039904873411038529684473891392104152677551989278815089949043159200373061921992851799948057507078358356630228490883482290389217471790233756775862302710944760078623023456856105493",
        //    100, "12064286")]
        //public void FlawedFrequencyTransmissionPartTwoWorks(string input, int numberOfPhases, string expectedOutput)
        //{
        //    //Arrange
        //    IBasePatternGenerator basePatternGenerator = new BasePatternGenerator();
        //    FlawedFrequencyTransmission flawedFrequencyTransmission = new FlawedFrequencyTransmission(basePatternGenerator);

        //    //Act
        //    string actualOutput = flawedFrequencyTransmission.CalculatePartTwoOutputSignalFor(input, numberOfPhases);

        //    //Assert
        //    Assert.Equal(expectedOutput, actualOutput);
        //}
    }
}