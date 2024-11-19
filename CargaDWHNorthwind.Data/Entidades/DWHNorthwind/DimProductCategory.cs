

using System.ComponentModel.DataAnnotations.Schema;

namespace CargaDWHNorthwind.Data.Entidades.DWHNorthwind
{
    [Table("DimProduct/Categories")]
    public class DimProductCategory
    {
        public int ProductKey { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string? ProductName { get; set; }
        public string? CategoryName { get; set; }

    }
}
