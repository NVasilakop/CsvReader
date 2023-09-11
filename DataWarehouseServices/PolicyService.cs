using Dapper;
using DataModels;
using DataWarehouseInterfaces;
using Npgsql;

namespace DataWarehouseServices
{
    public class PolicyService : IPolicyService
    {
        public Task WritePoliciesToDB(IEnumerable<Policy> policies, NpgsqlConnection conn)
        {
            string command = "INSERT INTO Policy (id, created_timestamp,updated_timestamp,distribution_channel,end_date,intermediary_name,premium_breakdown,product,quote_reference,start_date,sum_assured,total_premium,vehicle_cc,vehicle_model,vehicle_make,vehicle_registration_date,numberplate,vehicle_type)" +
               " VALUES (@Id,@CreatedTimestamp,@UpdatedTimestamp,@DistributionChannel,@EndDate,@IntermediaryName,@PremiumBreakdown,@Product,@QuoteReference,@StartDate,@SumAssured,@TotalPremium,@VehicleCc,@VehicleModel,@VehicleMake,@VehicleRegistrationDate,@Numberplate,@VehicleType)";
            return  conn.ExecuteAsync(command, policies);
        }
    }
}
