using FormuleCirkelEntity.Models;
using FormuleCirkelEntity.ResultGenerators;
using System;
using Xunit;

namespace FormulaCirkelEntity.Tests
{
    public class RaceResultGeneratorTests
    {
        // Test underneath should be redone considering recent changes.
        //
        //[Theory]
        //[InlineData(23)]
        //[InlineData(20)]
        //[InlineData(17)]
        //public void DriverLevelBonus_StyleAddition_Correct(int expected)
        //{
        //    // Arrange
        //    RaceResultGenerator generator = new RaceResultGenerator(new Random(1));
        //    SeasonDriver driver = new SeasonDriver()
        //    {
        //        Skill = 20
        //    };

        //    // Act
        //    int driverLevelBonus = generator.GetDriverLevelBonus(driver);

        //    // Assert
        //    Assert.Equal(expected, driverLevelBonus);
        //}

        [Theory]
        [InlineData(1, 75)]
        [InlineData(26, 0)]
        [InlineData(5, 63)]
        [InlineData(10, 48)]
        [InlineData(15, 33)]
        [InlineData(20, 18)]
        public void DriverQualifyingBonus_Calculation_Correct(int qualifyingPosition, int expected)
        {
            // Arrange
            RaceResultGenerator generator = new RaceResultGenerator(new Random(1));

            // Act
            var qualifyingBonus = generator.GetQualifyingBonus(qualifyingPosition, 26, 3);

            // Assert
            Assert.Equal(expected, qualifyingBonus);
        }

        // Test underneath should be redone considering recent changes.
        //
        // The Driver Reliability Result uses a combination of Team Reliability and Driver Style to get the Driver Reliability Score.
        // It is compared against a random value to determine whether the random Value is greater, equal or less than the result.
        // Aggressive subtracts 2 off the team reliability, defensive adds 2, and neutral stays equal.
        // Thus, use a static random value of 1 and a Team Reliability of 2 to test the Reliability Score generation.
        //[Theory]
        //[InlineData(Style.Aggressive, -1)]
        //[InlineData(Style.Neutral, 0)]
        //[InlineData(Style.Defensive, 1)]
        //public void DriverReliability_Style_Correct(Style style, int expected)
        //{
        //    // Arrange
        //    RaceResultGenerator generator = new RaceResultGenerator(new StaticRandom(1));
        //    SeasonDriver driver = new SeasonDriver()
        //    {
        //        Style = style,
        //        SeasonTeam = new SeasonTeam()
        //        {
        //            Reliability = 1
        //        }
        //    };

        //    // Act
        //    int driverLevelBonus = generator.GetDriverReliabilityResult(driver, 0);

        //    // Assert
        //    Assert.Equal(expected, driverLevelBonus);
        //}

        class StaticRandom : Random
        {
            readonly int _staticValue;

            public StaticRandom(int staticValue)
            {
                _staticValue = staticValue;
            }

            public override int Next()
            {
                return _staticValue;
            }

            public override int Next(int maxValue)
            {
                return Next();
            }

            public override int Next(int minValue, int maxValue)
            {
                return Next();
            }
        }
    }
}
