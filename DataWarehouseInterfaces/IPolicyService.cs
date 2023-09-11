using DataModels;
using Npgsql;

namespace DataWarehouseInterfaces
{
    public interface IPolicyService
    {
        Task WritePoliciesToDB(IEnumerable<Policy> policies, NpgsqlConnection conn);
    }
}
