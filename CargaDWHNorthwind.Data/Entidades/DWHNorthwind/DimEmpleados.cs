

using System.ComponentModel.DataAnnotations.Schema;

namespace CargaDWHNorthwind.Data.Entidades.DWHNorthwind
{
    [Table("DimEmpleados")]
    public class DimEmpleados
    {
        public int Empleadoskey {  get; set; }
        public string? NombreEmpleado { get; set; }

    }
}
