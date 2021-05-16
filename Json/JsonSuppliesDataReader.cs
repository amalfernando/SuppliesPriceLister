using System;
using System.IO;
using System.Linq;
using SuppliesPriceLister.Json.Models;
using SuppliesPriceLister.Shared;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace SuppliesPriceLister.Json
{
    public class JsonSuppliesDataReader : SuppliesDataReader
    {
        private string FilePath { get; set; }
        private decimal InverseExchangeRate { get; set; }

        public JsonSuppliesDataReader(string fileName, IConfigurationRoot configuration)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("FileName cannot be null or empty.");

            FilePath = GetFilePath(fileName);

            if (configuration == null)
                throw new ArgumentException("Configuration cannot be null.");

            decimal exchangeRate = Convert.ToDecimal(configuration.GetSection("audUsdExchangeRate").Value);
            InverseExchangeRate = 1 / exchangeRate;
        }

        public override void Load()
        {
            using StreamReader file = new StreamReader(FilePath);
            string json = file.ReadToEnd();
            var data = JsonConvert.DeserializeObject<Root>(json);
            if (data != null)
                Supplies = data.Partners.SelectMany(p => p.Supplies).Select(s => new SuppliesPriceLister.Shared.Models.Supply
                {
                    Id = s.Id.ToString(),
                    ItemName = s.Description,
                    PriceInCent = Convert.ToInt16(s.PriceInCents * InverseExchangeRate),
                });
        }
    }
}
