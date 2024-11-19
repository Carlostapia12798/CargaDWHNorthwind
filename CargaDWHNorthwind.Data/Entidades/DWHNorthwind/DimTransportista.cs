

using System.ComponentModel.DataAnnotations.Schema;

namespace CargaDWHNorthwind.Data.Entidades.DWHNorthwind
{
    [Table("DimTransportista")]
    public class DimTransportista
    {
        public int TransportistaKey { get; set; }
        public string? NombreTransportista { get; set; }

    }
}
