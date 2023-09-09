using Dapper;
using DataModels;
using DataWarehouseInterfaces;
using Npgsql;
using Utilizer;

namespace DataWarehouseServices
{
    public class UserSessionService : IUserSessionService
    {

        public async Task WriteUserSessionsToDB(IEnumerable<UserSession> userSessions, NpgsqlConnection conn)
        {
            string command = "INSERT INTO UserSession (userid, id, record_creation_ts,last_record_update_ts,paths,entry_ts,exit_ts)" +
                " VALUES (@UserId, @Id,@Record_Creation_Ts,@Last_Record_Update_Ts,@Paths,@Entry_Ts,@Exit_Ts)";
            var result = await conn.ExecuteAsync(command, userSessions);
        }
    }
}