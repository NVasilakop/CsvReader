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
    public class QuoteService : IQuoteService
    {
        public async Task WriteQuotesToDB(IEnumerable<Quote> quotes, NpgsqlConnection conn)
        {
            string command = "INSERT INTO Quote (id, event_type,quote_reference,created_timestamp,updated_timestamp,distribution_channel,intermediary_name,date_of_birth,vehicle_cc,vehicle_model,vehicle_make,vehicle_registration_date,numberplate,vehicle_type,end_date,product,start_date,sum_assured,total_premium)" +
               " VALUES (@Id,@EventType,@QuoteReference,@CreatedTimestamp,@UpdatedTimestamp,@DistributionChannel,@IntermediaryName,@DateOfBirth,@VehicleCc,@VehicleModel,@VehicleMake,@VehicleRegistrationDate,@Numberplate,@VehicleType,@EndDate,@Product,@StartDate,@SumAssured,@TotalPremium)";
            var result = await conn.ExecuteAsync(command, quotes);
        }
    }
}
