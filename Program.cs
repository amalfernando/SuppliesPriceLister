using System;
using System.Linq;
using SuppliesPriceLister.Csv;
using SuppliesPriceLister.Shared;
using SuppliesPriceLister.Shared.Models;

namespace SuppliesPriceLister
{
    class Program
    {
        static void Main(string[] args)
        {
            SuppliesData suppliesDataFromCsv = new SuppliesData(new CsvSuppliesDataReader("humphries.csv"));
            suppliesDataFromCsv.Load();

            OutputSupplierData(suppliesDataFromCsv);

            Console.ReadKey();
        }

        static void OutputSupplierData(SuppliesData csvSuppliesData)
        {
            var sortedSuppliesData = csvSuppliesData.GetSupplies().ToList()
                .OrderByDescending(s => s.PriceInCent);

            Console.WriteLine("{0}  {1}  {2}", "[Id]", "[Item Name]", "[Price]");

            foreach (Supply supply in sortedSuppliesData)
            {
                Console.WriteLine("{0}, {1}, {2}", supply.Id, supply.ItemName, supply.PriceInDollar);
            }
        }
    }
}
