using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public sealed class Quote_Event
    {
        [Ignore]
        public string FirstColumn { get; set; }

        [Name("Id")]
        public string Id { get; set; }

        [Name("EventType")]
        public string EventType { get; set; }

        [Name("QuoteReference")]
        public string QuoteReference { get; set; }

        [Name("CreatedTimestamp")]
        public DateTime CreatedTimestamp { get; set; }

        [Name("UpdatedTimestamp")]
        public DateTime UpdatedTimestamp { get; set; }

        [Name("DistributionChannel")]
        public string DistributionChannel { get; set; }

        [Name("IntermediaryName")]
        public string IntermediaryName { get; set; }

        [Name("DateOfBirth")]
        public string DateOfBirth { get; set; }

        [Name("VehicleCc")]
        public string VehicleCc { get; set; }
        [Name("VehicleModel")]
        public string VehicleModel { get; set; }

        [Name("VehicleMake")]
        public string VehicleMake { get; set; }

        [Name("VehicleRegistrationDate")]
        public string VehicleRegistrationDate { get; set; }

        [Name("Numberplate")]
        public string Numberplate { get; set; }

        [Name("VehicleType")]
        public string VehicleType { get; set; }

        [Name("EndDate")]
        public string EndDate { get; set; }

        [Name("Product")]
        public string Product { get; set; }

        [Name("StartDate")]
        public string StartDate { get; set; }

        [Name("sumAssured")]
        public string SumAssured { get; set; }
        [Name("TotalPremium")]
        public string TotalPremium { get; set; }

    }
}
