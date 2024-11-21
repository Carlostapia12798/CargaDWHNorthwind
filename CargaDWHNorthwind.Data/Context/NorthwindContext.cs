

using CargaDWHNorthwind.Data.Entidades.northwind;
using Microsoft.EntityFrameworkCore;

namespace CargaDWHNorthwind.Data.Context
{
    public partial class NorthwindContext: DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options) 
        { 
        
        }

        //DBSETS //
        #region "Db Sets"
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Shippers> Shippers { get; set; }
        #endregion

    }
}
