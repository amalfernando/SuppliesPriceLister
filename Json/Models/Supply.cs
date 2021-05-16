namespace SuppliesPriceLister.Json.Models
{
    public class Supply
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
        public int PriceInCents { get; set; }
        public string ProviderId { get; set; }
        public string MaterialType { get; set; }
    }
}
