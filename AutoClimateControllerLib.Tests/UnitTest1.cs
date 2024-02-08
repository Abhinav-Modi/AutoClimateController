using Xunit;
using System;
using System.IO;

namespace AutoClimateControllerLib.Tests
{
    public class AutoClimateControllerTests
    {
        private StringWriter _outputWriter;
        private string _consoleOutput;

        public AutoClimateControllerTests()
        {
            _outputWriter = new StringWriter();
            Console.SetOut(_outputWriter);
        }
        
        [Theory]
        [InlineData(5, 22, 19.8)] // Expected occupancy, outside temp, and calculated temperature
        public void AdjustClimate_ShouldChangeTemperature(int expectedOccupancy, int expectedOutsideTemp, double expectedTemperature)
        {
            // Arrange
            var autoClimateController = new AutoClimateController();

            // Act
            autoClimateController.AdjustClimate();

            // Assert
            _consoleOutput = _outputWriter.ToString().Trim();
            Assert.Contains($"Temperature changed to: {expectedTemperature}", _consoleOutput);
        }
    }
}
