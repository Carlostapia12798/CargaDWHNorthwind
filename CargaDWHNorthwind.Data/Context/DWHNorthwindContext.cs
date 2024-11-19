

using CargaDWHNorthwind.Data.Entidades.DWHNorthwind;
using Microsoft.EntityFrameworkCore;

namespace CargaDWHNorthwind.Data.Context
{
    public partial class DWHNorthwindContext: DbContext
    {

        public DWHNorthwindContext(DbContextOptions<DWHNorthwindContext>options): base(options) 
        { 

        }

        #region "Db Sets"
        public DbSet<DimClientes> DimClientes { get; set; }
        public DbSet<DimDate> DimDates { get; set; }
        public DbSet<DimEmpleados> DimEmpleados { get; set; }
        public DbSet<DimProductCategory> DimProductCategories { get; set; }
        public DbSet<DimTransportista> DimTransportista { get; set; }
        #endregion

    }
}
