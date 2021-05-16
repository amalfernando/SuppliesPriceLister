using System.Collections.Generic;
using System.Linq;
using SuppliesPriceLister.Shared.Models;

namespace SuppliesPriceLister.Shared
{
    public class SuppliesData
    {
        private readonly ISuppliesDataReader _suppliesDataReader;
        
        public SuppliesData(ISuppliesDataReader suppliesDataReader)
        {
            _suppliesDataReader = suppliesDataReader;
        }

        public void Load()
        {
            this._suppliesDataReader.Load();
        }

        public List<Supply> GetSupplies()
        {
            return _suppliesDataReader.Supplies?.ToList();
        }
    }
}
