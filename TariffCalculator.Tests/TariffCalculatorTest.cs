using System;
using Xunit;
using TariffCalculator.Services.TariffCalculator;

namespace TariffCalculator.Tests
{
    public class TariffCalculatorTest
    {
        [Theory]
        [InlineData(3500, 830)]
        [InlineData(4500, 1050)]
        [InlineData(0, 60)]
        public void CalculateAnnualCost_ShouldReturnCorrectCost_ForBasicTariff(int consumption, decimal expectedCost)
        {
            //Arrange
            var baseCalculator = new BasicTariffCalculator(5, 22);

            //Act
            var actualCost = baseCalculator.CalculateAnnualCost(consumption);

            //Assert
            Assert.Equal(expectedCost, actualCost);
        }

        [Theory]
        [InlineData(3500, 800)]
        [InlineData(4500, 950)]
        [InlineData(4000, 800)]
        [InlineData(0, 800)]
        public void CalculateAnnualCost_ShouldReturnCorrectCost_ForPackagedTariff(int consumption, decimal expectedCost)
        {
            //Arrange
            var packagedCalculator = new PackagedTariffCalculator(800, 30, 4000);

            //Act
            var actualCost = packagedCalculator.CalculateAnnualCost(consumption);

            //Assert
            Assert.Equal(expectedCost, actualCost);
        }
    }
}
