
using CargaDWHNorthwind.Data.Results;

namespace CargaDWHNorthwind.Data.Interfaces
{
    public interface IDataServiceDWHNorthwind
    {
        Task<OperationResult> LoadDimEmpleados();
        Task<OperationResult> LoadDimClientes();
        Task<OperationResult> LoadDimProductCategory();
        Task<OperationResult> LoadDimTransportista();
        Task<OperationResult> LoadDimDate(DateOnly? dayOfYear);

    }
}
