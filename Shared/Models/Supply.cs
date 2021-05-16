using System;

namespace SuppliesPriceLister.Shared.Models
{
    public class Supply
    {
        public string Id { get; set; }
        public string ItemName { get; set; }
        public int PriceInCent { get; set; }
        public decimal PriceInDollar => GetRoundedValue(PriceInCent / 100m);

        private decimal GetRoundedValue(decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.ToEven);
        }
    }
}
