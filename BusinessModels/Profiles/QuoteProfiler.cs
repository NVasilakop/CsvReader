using AutoMapper;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.Profiles
{
    public class QuoteProfiler : Profile
    {
        public QuoteProfiler()
        {
            CreateMap<Quote_Event, Quote>();
            //.ForMember(dest => dest.CreatedTimestamp, opt => opt.MapFrom(source => source.CreatedTimestamp))
            //.ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(source => source.DateOfBirth))
            //.ForMember(dest => dest.QuoteReference, opt => opt.MapFrom(source => source.QuoteReference))
            //.ForMember(dest => dest.VehicleMake, opt => opt.MapFrom(source => source.VehicleMake))
            //.ForMember(dest => dest.Product, opt => opt.MapFrom(source => source.Product))
            //.ForMember(dest => dest.SumAssured, opt => opt.MapFrom(source => decimal.Parse(source.SumAssured)))
            //.ForMember(dest => dest.DistributionChannel, opt => opt.MapFrom(source => source.DistributionChannel))
            //.ForMember(dest => dest.UpdatedTimestamp, opt => opt.MapFrom(source => source.UpdatedTimestamp))
            //.ForMember(dest => dest.EndDate, opt => opt.MapFrom(source => DateTime.Parse(source.EndDate)))
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
            //.ForMember(dest => dest.IntermediaryName, opt => opt.MapFrom(source => source.IntermediaryName))
            //.ForMember(dest => dest.VehicleType, opt => opt.MapFrom(source => source.VehicleType))
            //.ForMember(dest => dest.VehicleRegistrationDate, opt => opt.MapFrom(source => DateTime.Parse(source.VehicleRegistrationDate)))
            //.ForMember(dest => dest.VehicleCc, opt => opt.MapFrom(source => source.VehicleCc))
            //.ForMember(dest => dest.TotalPremium, opt => opt.MapFrom(source => decimal.Parse(source.TotalPremium)))
            //.ForMember(dest => dest.VehicleModel, opt => opt.MapFrom(source => source.VehicleModel))
            //.ForMember(dest => dest.StartDate, opt => opt.MapFrom(source => DateTime.Parse(source.StartDate)))
            //.ForMember(dest => dest.EventType, opt => opt.MapFrom(source => source.EventType))
            //.ForMember(dest => dest.Numberplate, opt => opt.MapFrom(source => source.Numberplate));

            CreateMap<Quote, Quote_Event>();

        }
    }
}
