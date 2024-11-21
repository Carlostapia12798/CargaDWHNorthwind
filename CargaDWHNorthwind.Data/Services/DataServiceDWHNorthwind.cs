
using CargaDWHNorthwind.Data.Context;
using CargaDWHNorthwind.Data.Entidades.DWHNorthwind;
using CargaDWHNorthwind.Data.Entidades.northwind;
using CargaDWHNorthwind.Data.Interfaces;
using CargaDWHNorthwind.Data.Results;

namespace CargaDWHNorthwind.Data.Services
{
    public class DataServiceDWHNorthwind : IDataServiceDWHNorthwind
    {
        private readonly NorthwindContext _northwindContext;
        private readonly DWHNorthwindContext _dWHNorthwindContext;
        public DataServiceDWHNorthwind(NorthwindContext northwindContext, 
                                        DWHNorthwindContext dWHNorthwindContext) 
        {
            _northwindContext = northwindContext;
            _dWHNorthwindContext = dWHNorthwindContext;
        }

        public async Task<OperationResult> LoadDimEmpleados() 
        {
            OperationResult result= new OperationResult();

            try
            {
                //obtener los empleados de la base de datos de Northwind
                var empleados = _northwindContext.Employees.Select(emp => new DimEmpleados() 
                {
                    NombreEmpleado =string.Concat(emp.FirtsName," ",emp.LastName)

                }).ToList();

                // cargar la dimencion empleados de DWHNorthwind.
                await _dWHNorthwindContext.DimEmpleados.AddRangeAsync(empleados);

                await _dWHNorthwindContext.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                result.Success = false;
                result.Message = $"Error cargando la Dimension de empleados. {ex.Message}";
            }

            return result;
        }
        public async Task<OperationResult> LoadDimClientes()
        {
            OperationResult result = new OperationResult();

            try
            {
                //obtener los empleados de la base de datos de Northwind
                var cliente = _northwindContext.Customers.Select(cli => new DimClientes()
                {
                    ClienteId = cli.CustomerID,
                    NombreCliente = cli.CompanyName
                }).ToList();

                // cargar la dimencion clientes de DWHNorthwind.
                await _dWHNorthwindContext.DimClientes.AddRangeAsync(cliente);

                await _dWHNorthwindContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la Dimension de clientes. {ex.Message}";
            }
            return result;
        }
        public async Task<OperationResult> LoadDimProductCategory()
        {
            OperationResult result = new OperationResult();

            try
            {
                // obtener los products, categories de Northwind
                var ProductCategories = (from Products in _northwindContext.Products
                             join Category in _northwindContext.Categories on Products.CategoryID equals Category.CategoryID
                             select new DimProductCategory()
                             {
                                 CategoryId = Category.CategoryID,
                                 ProductId = Products.ProductID,
                                 ProductName = Products.ProductName,
                                 CategoryName = Category.CategoryName
                             }).ToList();

                // cargar la dimencion ProductCategories de DWHNorthwind.
                await _dWHNorthwindContext.DimProductCategories.AddRangeAsync(ProductCategories);

                await _dWHNorthwindContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la Dimension de Producto y Categoria. { ex.Message}";
            }

            return result;
        }
        public async Task<OperationResult> LoadDimTransportista()
        {
            OperationResult result = new OperationResult();

            try
            {
                //obtener los empleados de la base de datos de Northwind
                var transportista = _northwindContext.Shippers.Select(tra => new DimTransportista()
                {
                    NombreTransportista = tra.CompanyName
                }).ToList();

                // cargar la dimencion clientes de DWHNorthwind.
                await _dWHNorthwindContext.DimTransportista.AddRangeAsync(transportista);

                await _dWHNorthwindContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error cargando la Dimension de clientes. {ex.Message}";
            }
            return result;
        }
        public async Task<OperationResult> LoadDimDate(DateOnly? dayOfYear)
        {
            OperationResult result = new OperationResult();

            try
            {
                // Transformar fechas únicas de OrderDate directamente a registros DimDate
                var Dates = (from Orders in _northwindContext.Orders
                             select Orders.OrderDate.Date) // Extraer solo la parte de la fecha
                               .Distinct()
                               .Select(date => new DimDate()
                               {
                                   DateOrder = int.Parse(date.ToString("yyyyMMdd")),
                                   Date = dayOfYear,                                   
                                   DateName = date.ToString("dddd, d MMMM yyyy"), 
                                   Month = date.Month,                            
                                   MonthName = date.ToString("MMMM"),             
                                   Year = date.Year,                              
                                   YearName = $"Year {date.Year}"                 
                               }).ToList();

                // Insertar las fechas en DimDate del DWH
                await _dWHNorthwindContext.DimDates.AddRangeAsync(Dates);

                // Guardar cambios en la base de datos
                await _dWHNorthwindContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error al cargar DimDate: {ex.Message}";
            }

            return result;
        }
    }
}
