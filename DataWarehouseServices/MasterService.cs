using Dapper;
using DataWarehouseInterfaces;
using Npgsql;
using System.Data;

namespace DataWarehouseServices
{
    public class MasterService : IMasterService
    {
        public Task WriteMasterToDB(NpgsqlConnection conn)
        {
            string command = "SELECT InsertMasterDataIntoMasterTable();";
            return conn.ExecuteAsync(command,CommandType.Text);
        }
    }
}
