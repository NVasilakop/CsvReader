using DataModels;
using Npgsql;

namespace DataWarehouseInterfaces
{
    public interface IQuoteService
    {
        Task WriteQuotesToDB(IEnumerable<Quote> quotes, NpgsqlConnection conn);
        Task WriteQuotesSnapshotsToDB(IEnumerable<Quote> quotes, NpgsqlConnection conn);

    }
}
