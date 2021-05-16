using System.Collections.Generic;
using SuppliesPriceLister.Shared.Models;

namespace SuppliesPriceLister.Shared
{
    public interface ISuppliesDataReader
    {
        IEnumerable<Supply> Supplies { get; set; }
        void Load();
    }
}
