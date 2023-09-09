using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public sealed class Policy
    {
        [Ignore]
        public string FirstColumn { get; set; }

        [Name("Id")]
        public string Id { get; set; }

        [Name("CreatedTimestamp")]
        public DateTime CreatedTimestamp { get; set; }

        [Name("UpdatedTimestamp")]
        public DateTime UpdatedTimestamp { get; set; }

        [Name("DistributionChannel")]
        public string DistributionChannel { get; set; }

        [Name("EndDate")]
        public DateTime EndDate { get; set; }

        [Name("IntermediaryName")]
        public string IntermediaryName { get; set; }

        [Name("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Name("PremiumBreakdown")]
        public string PremiumBreakdown { get; set; }

        [Name("Product")]
        public string Product { get; set; }

        [Name("QuoteReference")]
        public string QuoteReference { get; set; }

        [Name("StartDate")]
        public DateTime StartDate { get; set; }

        [Name("sumAssured")]
        public string SumAssured { get; set; }

        [Name("TotalPremium")]
        public string TotalPremium { get; set; }

        [Name("VehicleCc")]
        public string VehicleCc { get; set; }

        [Name("VehicleModel")]
        public string VehicleModel { get; set; }

        [Name("VehicleMake")]
        public string VehicleMake { get; set; }

        [Name("VehicleRegistrationDate")]
        public DateTime VehicleRegistrationDate { get; set; }

        [Name("Numberplate")]
        public string Numberplate { get; set; }

        [Name("VehicleType")]
        public string VehicleType { get; set; }

    }
}
