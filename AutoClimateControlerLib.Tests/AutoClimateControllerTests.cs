using AutoClimateControlerLib;
using Xunit;
namespace AutoClimateControlerLib.Tests
{
    public class AutoClimateControllerTests
    {
        [Fact]
        public void AdjustClimate_ShouldCallSensorsAndRegulator()
        {
            // Arrange
            var mockOccupancySensor = new Mock<ISensor>();
            var mockTempSensor = new Mock<ISensor>();
            var mockTempCalculator = new Mock<ITempCalculator>();
            var mockRegulator = new Mock<IRegulator>();

            mockOccupancySensor.Setup(s => s.GetValue()).Returns(5);
            mockTempSensor.Setup(s => s.GetValue()).Returns(22);
            mockTempCalculator.Setup(c => c.CalculateNewTemperature(5, 22)).Returns(110);

            var controller = new AutoClimateController(mockOccupancySensor.Object, mockTempSensor.Object, mockTempCalculator.Object, mockRegulator.Object);

            // Act
            controller.AdjustClimate();

            // Assert
            mockOccupancySensor.Verify(s => s.GetValue(), Times.Once());
            mockTempSensor.Verify(s => s.GetValue(), Times.Once());
            mockTempCalculator.Verify(c => c.CalculateNewTemperature(5, 22), Times.Once());
            mockRegulator.Verify(r => r.ChangeTemp(110), Times.Once());
        }
    }
}