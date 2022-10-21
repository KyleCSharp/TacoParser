using Microsoft.VisualStudio.TestPlatform.Common.Interfaces;
using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
           

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expected)
        {
           
            //Arrange
            var tacoParser = new TacoParser();
            //Act
            var actual = tacoParser.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Location.Longitude);



        }


       
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        public void ShouldParselatitude(string line, double expected)
        {
            

            //Arrange
            var tacoParser = new TacoParser();
            //Act
            ITrackable actual = tacoParser.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Location.Latitude);



        }

    }
}
