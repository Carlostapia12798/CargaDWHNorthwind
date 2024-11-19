

using System.ComponentModel.DataAnnotations.Schema;

namespace CargaDWHNorthwind.Data.Entidades.DWHNorthwind
{
    [Table("DimClientes")]
    public class DimClientes
    {

        public int ClientesKey { get; set; }
        public int ClienteId { get; set; }
        public string? NombreCliente { get; set; }

    }
}
