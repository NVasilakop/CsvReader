using DataModels;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouseInterfaces
{
    public interface IQuoteService
    {
        Task WriteQuotesToDB(IEnumerable<Quote> quotes, NpgsqlConnection conn);
        Task WriteQuotesSnapshotsToDB(IEnumerable<Quote> quotes, NpgsqlConnection conn);

    }
}
