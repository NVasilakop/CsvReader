using Dapper;
using DataModels;
using DataWarehouseInterfaces;
using Npgsql;
using System.Transactions;
using Utilizer;
using Z.Dapper.Plus;

namespace DataWarehouseServices
{
    public class UserSessionService : IUserSessionService
    {
        public  Task WriteUserSessionQuotesToDB(IEnumerable<UserSessionQuote> userSessionQuotes, NpgsqlConnection conn)
        {
            string command = $@"INSERT INTO UserSessionQuote (userid, sessionid, record_creation_ts,last_record_update_ts,path,pathraw,event_ts,product,q_ref ,entry_ts,exit_ts) " +
                "VALUES (@UserId, @Id,@Record_Creation_Ts,@Last_Record_Update_Ts,@Path,@PathRaw,@Event_Ts,@Product,@QuoteReference,@Entry_Ts,@Exit_Ts)";
           return conn.ExecuteAsync(command, userSessionQuotes);
        }

        public  Task WriteUserSessionsToDB(IEnumerable<UserSession> userSessions, NpgsqlConnection conn)
        {
            string command = "INSERT INTO UserSession (userid, id, record_creation_ts,last_record_update_ts,paths,entry_ts,exit_ts)" +
                " VALUES (@UserId, @Id,@Record_Creation_Ts,@Last_Record_Update_Ts,@Paths,@Entry_Ts,@Exit_Ts)";
            return  conn.ExecuteAsync(command, userSessions);
        }
    }
}