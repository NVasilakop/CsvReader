using DataModels;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouseInterfaces
{
    public interface IPolicyService
    {
        Task WritePoliciesToDB(IEnumerable<Policy> policies, NpgsqlConnection conn);
    }
}
