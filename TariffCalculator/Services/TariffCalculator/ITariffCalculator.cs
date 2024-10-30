using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TariffCalculator.Services.TariffCalculator
{
    public interface ITariffCalculator
    {
        decimal CalculateAnnualCost(int consumption);
    }
}
