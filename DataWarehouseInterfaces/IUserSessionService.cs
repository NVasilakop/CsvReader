using DataModels;
using Npgsql;

namespace DataWarehouseInterfaces
{
    public interface IUserSessionService
    {
        Task WriteUserSessionsToDB(IEnumerable<UserSession> userSessions, NpgsqlConnection conn);
        Task WriteUserSessionQuotesToDB(IEnumerable<UserSessionQuote> userSessionQuotes, NpgsqlConnection conn);
    }
}