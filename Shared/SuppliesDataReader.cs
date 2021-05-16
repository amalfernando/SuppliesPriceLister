using System.Collections.Generic;
using System.IO;
using SuppliesPriceLister.Shared.Models;

namespace SuppliesPriceLister.Shared
{
    public abstract class SuppliesDataReader : ISuppliesDataReader
    {
        public IEnumerable<Supply> Supplies { get; set; }
        public abstract void Load();

        protected string GetFilePath(string fileName)
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + fileName;
        }
    }
}
