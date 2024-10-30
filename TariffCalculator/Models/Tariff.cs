using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TariffCalculator.Models
{
    public class Tariff
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public decimal BaseCost { get; set; }
        public decimal AdditionalKwhCost { get; set; }
        public int IncludedKwh { get; set; }
    }
}
