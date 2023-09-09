using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public sealed class Policy
    {
        public string Id { get; set; }
        public DateTime CreatedTimestamp { get; set; }

        public DateTime UpdatedTimestamp { get; set; }

        public string DistributionChannel { get; set; }

        public DateTime EndDate { get; set; }

        public string IntermediaryName { get; set; }

        public string PremiumBreakdown { get; set; }

        public string Product { get; set; }

        public string QuoteReference { get; set; }

        public DateTime StartDate { get; set; }

        public string SumAssured { get; set; }
    
        public string TotalPremium { get; set; }

        public string VehicleCc { get; set; }

        public string VehicleModel { get; set; }

        public string VehicleMake { get; set; }

        public DateTime VehicleRegistrationDate { get; set; }

        public string Numberplate { get; set; }

        public string VehicleType { get; set; }
    }
}
