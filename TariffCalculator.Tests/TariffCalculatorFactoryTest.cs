using System;
using TariffCalculator.Models;
using TariffCalculator.Services;
using TariffCalculator.Services.TariffCalculator;
using Xunit;

namespace TariffCalculator.Tests
{
    public class TariffCalculatoFactoryTest
    {
        [Fact]
        public void GetCalculatorType_ShouldReturnBaseCalculator_ForType1()
        {
            // Arrange
            var tariff = new Tariff
            {
                Type = 1,
                BaseCost = 5,
                AdditionalKwhCost = 22
            };

            //Act
            var actualTariffType = TariffCalculatorFactory.GetTariffType(tariff);

            //Assert
            Assert.IsType<BasicTariffCalculator>(actualTariffType);
        }

        [Fact]
        public void GetCalculatorType_ShouldReturnPackagedCalculator_ForType2()
        {
            // Arrange
            var tariff = new Tariff
            {
                Type = 2,
                BaseCost = 800,
                AdditionalKwhCost = 30,
                IncludedKwh = 4000
            };

            //Act
            var actualTariffType = TariffCalculatorFactory.GetTariffType(tariff);

            //Assert
            Assert.IsType<PackagedTariffCalculator>(actualTariffType);
        }

        [Fact]
        public void GetCalculatorType_ShouldThrowException_ForOtherTypes()
        {
            // Arrange
            var tariff = new Tariff
            {
                Type = 10
            };

            //Act & Assert
            Assert.Throws<NotImplementedException>(() => TariffCalculatorFactory.GetTariffType(tariff));
        }
    }
}
