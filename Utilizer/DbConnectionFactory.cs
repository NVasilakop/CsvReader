using Dapper;
using Npgsql;

namespace Utilizer
{
    public class DbConnectionFactory : IDbConnectionFactory
    {

        private NpgsqlConnectionStringBuilder _connStringBuilder;
        public DbConnectionFactory(DBConnectionDetails connectionDetails)
        {
            _connStringBuilder = new NpgsqlConnectionStringBuilder();
            _connStringBuilder.Host = connectionDetails.Host;
            _connStringBuilder.Port = connectionDetails.Port;
            _connStringBuilder.Username = connectionDetails.UserCredentials.Username;
            _connStringBuilder.Password = connectionDetails.UserCredentials.Password;
            _connStringBuilder.Database = connectionDetails.DBName;
        }

        public NpgsqlConnection CreateConnection()
        {
            try
            {
                return new NpgsqlConnection(_connStringBuilder.ConnectionString);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task CreateDbTables()
        {

            var sql = """
               CREATE TABLE IF NOT EXISTS UserSession (
                id VARCHAR(255) PRIMARY KEY,
                userid VARCHAR(255),
                paths VARCHAR(32768),
                entry_ts TIMESTAMP,
                exit_ts TIMESTAMP,
                record_creation_ts TIMESTAMP,
                last_record_update_ts TIMESTAMP
            );

            CREATE TABLE IF NOT EXISTS Quote (
                id VARCHAR(255) PRIMARY KEY,
                event_type VARCHAR(255),
                quote_reference VARCHAR(255),
                created_timestamp TIMESTAMP,
                updated_timestamp TIMESTAMP,
                distribution_channel VARCHAR(255),
                intermediary_name VARCHAR(255),
                date_of_birth VARCHAR(255),
                vehicle_cc VARCHAR(255),
                vehicle_model VARCHAR(255),
                vehicle_make VARCHAR(255),
                vehicle_registration_date VARCHAR(255),
                numberplate VARCHAR(255),
                vehicle_type VARCHAR(255),
                end_date VARCHAR(255),
                product VARCHAR(255),
                start_date VARCHAR(255),
                sum_assured VARCHAR(255),
                total_premium VARCHAR(255)
            );

                CREATE TABLE IF NOT EXISTS Policy (
                id VARCHAR(255) PRIMARY KEY,
                created_timestamp TIMESTAMP,
                updated_timestamp TIMESTAMP,
                distribution_channel VARCHAR(255),
                end_date DATE,
                intermediary_name VARCHAR(255),
                premium_breakdown TEXT,
                product VARCHAR(255),
                quote_reference VARCHAR(255),
                start_date DATE,
                sum_assured VARCHAR(255),
                total_premium VARCHAR(255),
                vehicle_cc VARCHAR(255),
                vehicle_model VARCHAR(255),
                vehicle_make VARCHAR(255),
                vehicle_registration_date DATE,
                numberplate VARCHAR(255),
                vehicle_type VARCHAR(255)
            );
           
            """;
            try
            {
                using (var conn = CreateConnection())
                {
                    await conn.ExecuteAsync(sql);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}