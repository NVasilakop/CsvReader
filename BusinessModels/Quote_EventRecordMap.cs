﻿using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public sealed class Quote_EventRecordMap : ClassMap<Quote_Event>
    {
        public Quote_EventRecordMap()
        {
            Map(m => m.Id).Name("Id");
            Map(m => m.EventType).Name("EventType");
            Map(m => m.QuoteReference).Name("QuoteReference");
            Map(m => m.CreatedTimestamp).Name("CreatedTimestamp");
            Map(m => m.UpdatedTimestamp).Name("UpdatedTimestamp");
            Map(m => m.DistributionChannel).Name("DistributionChannel");
            Map(m => m.IntermediaryName).Name("IntermediaryName");
            Map(m => m.DateOfBirth).Name("DateOfBirth");
            Map(m => m.VehicleCc).Name("VehicleCc");
            Map(m => m.VehicleModel).Name("VehicleModel");
            Map(m => m.VehicleMake).Name("VehicleMake");
            Map(m => m.VehicleRegistrationDate).Name("VehicleRegistrationDate");
            Map(m => m.Numberplate).Name("Numberplate");
            Map(m => m.VehicleType).Name("VehicleType");
            Map(m => m.EndDate).Name("EndDate");
            Map(m => m.Product).Name("Product");
            Map(m => m.StartDate).Name("StartDate");
            Map(m => m.SumAssured).Name("sumAssured");
            Map(m => m.TotalPremium).Name("TotalPremium");
        }
    }
}
