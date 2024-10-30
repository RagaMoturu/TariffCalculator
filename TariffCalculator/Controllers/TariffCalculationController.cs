using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TariffCalculator.Models;
using TariffCalculator.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TariffCalculator.Controllers
{
    [Route("api/[controller]")]
    public class TariffCalculationController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public List<TariffResult> GetTariffs(int consumption)
        {
            var contentPath = $@"{Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."))}\Data";
            var tariffsJsonString = System.IO.File.ReadAllText($@"{contentPath}\electricityTriffs.json");

            var tariffs = JsonConvert.DeserializeObject<List<Tariff>>(tariffsJsonString);

            var tariffResult = new List<TariffResult>();

            foreach (var tariff in tariffs)
            {
                var tariffCalulator = TariffCalculatorFactory.GetTariffType(tariff);
                var annucalCost = tariffCalulator.CalculateAnnualCost(consumption);
                tariffResult.Add(new TariffResult
                {
                    TariffName = tariff.Name,
                    AnnualCost = annucalCost
                });
            }

            return tariffResult;
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
