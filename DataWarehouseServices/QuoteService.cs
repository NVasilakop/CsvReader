using Dapper;
using DataModels;
using DataWarehouseInterfaces;
using Npgsql;

namespace DataWarehouseServices
{
    public class QuoteService : IQuoteService
    {
        public Task WriteQuotesToDB(IEnumerable<Quote> quotes, NpgsqlConnection conn)
        {
            string command = "INSERT INTO Quote (id, event_type,quote_reference,created_timestamp,updated_timestamp,distribution_channel,intermediary_name,date_of_birth,vehicle_cc,vehicle_model,vehicle_make,vehicle_registration_date,numberplate,vehicle_type,end_date,product,start_date,sum_assured,total_premium)" +
               " VALUES (@Id,@EventType,@QuoteReference,@CreatedTimestamp,@UpdatedTimestamp,@DistributionChannel,@IntermediaryName,@DateOfBirth,@VehicleCc,@VehicleModel,@VehicleMake,@VehicleRegistrationDate,@Numberplate,@VehicleType,@EndDate,@Product,@StartDate,@SumAssured,@TotalPremium)";
            return conn.ExecuteAsync(command, quotes);
        }

        public Task WriteQuotesSnapshotsToDB(IEnumerable<Quote> quotes, NpgsqlConnection conn)
        {
            string command = "INSERT INTO Quote_Snapshot (id, event_type,quote_reference,created_timestamp,updated_timestamp,distribution_channel,intermediary_name,date_of_birth,vehicle_cc,vehicle_model,vehicle_make,vehicle_registration_date,numberplate,vehicle_type,end_date,product,start_date,sum_assured,total_premium)" +
               " VALUES (@Id,@EventType,@QuoteReference,@CreatedTimestamp,@UpdatedTimestamp,@DistributionChannel,@IntermediaryName,@DateOfBirth,@VehicleCc,@VehicleModel,@VehicleMake,@VehicleRegistrationDate,@Numberplate,@VehicleType,@EndDate,@Product,@StartDate,@SumAssured,@TotalPremium)";

            var collapsedQuotes = quotes.GroupBy(q => q.QuoteReference).Select(group => group.OrderByDescending(q => q.UpdatedTimestamp).First());

            return  conn.ExecuteAsync(command, collapsedQuotes);
        }
    }
}
