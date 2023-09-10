using Dapper;
using DataModels;
using DataWarehouseInterfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouseServices
{
    public class MasterService : IMasterService
    {
        public async Task WritMasterToDB(NpgsqlConnection conn)
        {
            string command = "SELECT InsertMasterDataIntoMasterTable();";
            var result = await conn.ExecuteAsync(command,CommandType.Text);
        }
    }
}
