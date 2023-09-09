using Dapper;
using DataModels;
using DataWarehouseInterfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWarehouseServices
{
    public class PolicyService : IPolicyService
    {
        public async Task WritePoliciesToDB(IEnumerable<Policy> policies, NpgsqlConnection conn)
        {
            string command = "INSERT INTO Policy (id, created_timestamp,updated_timestamp,distribution_channel,end_date,intermediary_name,premium_breakdown,product,quote_reference,start_date,sum_assured,total_premium,vehicle_cc,vehicle_model,vehicle_make,vehicle_registration_date,numberplate,vehicle_type)" +
               " VALUES (@Id,@CreatedTimestamp,@UpdatedTimestamp,@DistributionChannel,@EndDate,@IntermediaryName,@PremiumBreakdown,@Product,@QuoteReference,@StartDate,@SumAssured,@TotalPremium,@VehicleCc,@VehicleModel,@VehicleMake,@VehicleRegistrationDate,@Numberplate,@VehicleType)";
            var result = await conn.ExecuteAsync(command, policies);
        }
    }
}
