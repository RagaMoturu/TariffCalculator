using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TariffCalculator.Services.TariffCalculator
{
    public class PackagedTariffCalculator : ITariffCalculator
    {
        private decimal _baseCost;
        private decimal _additionalKwhCost;
        private int _includedKwh;

        public PackagedTariffCalculator(decimal baseCost, decimal additionalKwhCost, int includedKwh)
        {
            _baseCost = baseCost;
            _additionalKwhCost = additionalKwhCost;
            _includedKwh = includedKwh;
        }

        public decimal CalculateAnnualCost(int consumption)
        {
            if (consumption <= _includedKwh)
                return _baseCost;
            
            var additionalCost = (consumption - _includedKwh) * (_additionalKwhCost / 100);
            return _baseCost + additionalCost;
        }
    }
}

