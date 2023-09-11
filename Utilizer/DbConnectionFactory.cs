using Dapper;
using Npgsql;
using System.Drawing;
using System.Transactions;

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
            _connStringBuilder.KeepAlive = connectionDetails.KeepAlive;
            _connStringBuilder.CommandTimeout = connectionDetails.CommandTimeout;
            _connStringBuilder.Timeout = connectionDetails.Timeout;
            _connStringBuilder.Pooling = connectionDetails.Pooling;
            _connStringBuilder.MaxPoolSize = connectionDetails.MaxPoolSize;
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

             CREATE TABLE IF NOT EXISTS UserSessionQuote (
                id SERIAL PRIMARY KEY,
                sessionid VARCHAR(255),
                userid VARCHAR(255),
                entry_ts TIMESTAMP,
                exit_ts TIMESTAMP,
                path VARCHAR(255),
                pathraw VARCHAR(32768),
                event_ts TIMESTAMP,
                product VARCHAR(255),
                q_ref VARCHAR(255),
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

             CREATE TABLE IF NOT EXISTS Master (
                usersessionid VARCHAR(255),
                quoteproduct VARCHAR(255),
                event_type VARCHAR(255),
                quote_reference VARCHAR(255),
                path VARCHAR(255),
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
                total_premium VARCHAR(255),
                policy_id VARCHAR(255)
            );


            """;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    using (var conn = CreateConnection())
                    {
                        await conn.ExecuteAsync(sql);
                        await conn.ExecuteAsync(ReturnStoredProceduresSql());
                        scope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private string ReturnStoredProceduresSql()
        {
            return """
            CREATE OR REPLACE FUNCTION InsertMasterDataIntoMasterTable()
            RETURNS VOID AS $$
            BEGIN
                INSERT INTO master (usersessionid, quoteproduct, quote_reference,event_type,path,created_timestamp,updated_timestamp,distribution_channel,intermediary_name,date_of_birth,
                                         vehicle_make,vehicle_cc,vehicle_model,vehicle_registration_date,numberplate,vehicle_type,end_date,product,start_date,
                                        sum_assured,total_premium,policy_id)
                SELECT
                    us.sessionid,
                    us.product,
                    us.q_ref,
                    qs.event_type,
                    us.path,
            		qs.created_timestamp,
            		qs.updated_timestamp,
            		qs.distribution_channel,
            		qs.intermediary_name,
            		qs.date_of_birth,
                    qs.vehicle_make,
            		qs.vehicle_cc,
            		qs.vehicle_model,
            		qs.vehicle_registration_date,
            		qs.numberplate,
            		qs.vehicle_type,
            		qs.end_date,
            		qs.product,
            		qs.start_date,
            		qs.sum_assured,
            		qs.total_premium,
                    p.id
                FROM
                    usersessionquote us
                INNER JOIN
                    quote qs ON us.q_ref = qs.quote_reference
                LEFT JOIN
                    policy p ON qs.quote_reference = p.quote_reference
                WHERE
                    us.entry_ts IS NOT NULL
                    AND us.exit_ts IS NOT NULL
                    AND us.product = 'motor';
            END;
            $$ LANGUAGE plpgsql;

            """;
        }
    }
}