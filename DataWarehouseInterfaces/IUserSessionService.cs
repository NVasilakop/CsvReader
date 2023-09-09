using DataModels;
using Npgsql;

namespace DataWarehouseInterfaces
{
    public interface IUserSessionService
    {
        Task WriteUserSessionsToDB(IEnumerable<UserSession> userSessions, NpgsqlConnection conn);
    }
}