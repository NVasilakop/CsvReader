using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public sealed class Quote
    {
        public string Id { get; set; }
        public string EventType { get; set; }

        public string QuoteReference { get; set; }

        public DateTime CreatedTimestamp { get; set; }

        public DateTime UpdatedTimestamp { get; set; }

        public string DistributionChannel { get; set; }

        public string IntermediaryName { get; set; }

        public string DateOfBirth { get; set; }

        public string VehicleCc { get; set; }
        public string VehicleModel { get; set; }

        public string VehicleMake { get; set; }

        public string VehicleRegistrationDate { get; set; }

        public string Numberplate { get; set; }

        public string VehicleType { get; set; }

        public string EndDate { get; set; }

        public string Product { get; set; }

        public string StartDate { get; set; }

        public string SumAssured { get; set; }
        public string TotalPremium { get; set; }
    }
}
