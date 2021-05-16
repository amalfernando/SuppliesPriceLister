using System;
using System.IO;
using System.Linq;
using SuppliesPriceLister.Shared;
using SuppliesPriceLister.Shared.Models;

namespace SuppliesPriceLister.Csv
{
    public class CsvSuppliesDataReader : SuppliesDataReader
    {
        private string FilePath { get; set; }

        public CsvSuppliesDataReader(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("FileName cannot be null or empty.");

            FilePath = GetFilePath(fileName);
        }

        public override void Load()
        {
            Supplies = from data in File.ReadAllLines(this.FilePath).Skip(1)
                        let s = data.Split(',')
                        select new Supply
                        {
                            Id = s[0],
                            ItemName = s[1],
                            PriceInCent = Convert.ToInt32(Math.Round(Convert.ToDecimal(s[3]), 2) * 100),
                        };
        }
    }
}
