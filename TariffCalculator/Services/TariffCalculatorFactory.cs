using TariffCalculator.Models;
using TariffCalculator.Services.TariffCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TariffCalculator.Services
{
    public class TariffCalculatorFactory
    {
        public static ITariffCalculator GetTariffType(Tariff tariff)
        {
            switch (tariff.Type) {
                case 1:
                    return new BasicTariffCalculator(tariff.BaseCost, tariff.AdditionalKwhCost);
                case 2:
                    return new PackagedTariffCalculator(tariff.BaseCost, tariff.AdditionalKwhCost, tariff.IncludedKwh);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
