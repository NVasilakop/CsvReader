using Npgsql;

namespace DataWarehouseInterfaces
{
    public interface IMasterService
    {
        Task WriteMasterToDB(NpgsqlConnection conn);
    }
}
