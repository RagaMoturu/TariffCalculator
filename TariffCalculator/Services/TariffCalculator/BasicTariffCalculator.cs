using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TariffCalculator.Services.TariffCalculator
{
    public class BasicTariffCalculator : ITariffCalculator
    {
        private decimal _baseCost;
        private decimal _additionalKwhCost;

        public BasicTariffCalculator(decimal baseCost, decimal additionalKwhCost)
        {
            _baseCost = baseCost;
            _additionalKwhCost = additionalKwhCost;
        }

        public decimal CalculateAnnualCost(int consumption)
        {
            var annualBaseCost = _baseCost * 12;
            var consumptionCost = consumption * (_additionalKwhCost / 100);
            return annualBaseCost + consumptionCost;
        }
    }
}
