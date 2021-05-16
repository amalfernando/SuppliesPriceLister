using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using SuppliesPriceLister.Csv;
using SuppliesPriceLister.Json;
using SuppliesPriceLister.Shared;
using SuppliesPriceLister.Shared.Models;

namespace SuppliesPriceLister
{
    class Program
    {
        public static IConfigurationRoot configuration;

        static void Main(string[] args)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();
            
            SuppliesData suppliesDataFromCsv = new SuppliesData(new CsvSuppliesDataReader("humphries.csv"));
            suppliesDataFromCsv.Load();

            SuppliesData suppliesDataFromJson = new SuppliesData(new JsonSuppliesDataReader("megacorp.json", configuration));
            suppliesDataFromJson.Load();

            OutputSupplierData(suppliesDataFromCsv, suppliesDataFromJson);

            Console.ReadKey();
        }

        static void OutputSupplierData(SuppliesData csvSuppliesData, SuppliesData jsonSuppliesData)
        {
            var sortedSuppliesData = csvSuppliesData.GetSupplies().Concat(jsonSuppliesData.GetSupplies())
                .ToList()
                .OrderByDescending(s => s.PriceInCent);

            Console.WriteLine("{0}  {1}  {2}", "[Id]", "[Item Name]", "[Price]");

            foreach (Supply supply in sortedSuppliesData)
            {
                Console.WriteLine("{0}, {1}, {2}", supply.Id, supply.ItemName, supply.PriceInDollar);
            }
        }
    }
}
