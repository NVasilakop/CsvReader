using AutoMapper;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.Profiles
{
    public class SessionProfiler : Profile
    {
        public SessionProfiler()
        {
            CreateMap<Session,UserSession>()
                //.ForMember(dest => dest.PathRaw, opt => opt.MapFrom(source => source.Paths.PathRaw))
                //.ForMember(dest => dest.Path, opt => opt.MapFrom(source => source.Paths.Path))
                //.ForMember(dest => dest.Product, opt => opt.MapFrom(source => source.PathInfo.Product))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(source => source.UserId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.Exit_Ts, opt => opt.MapFrom(source => source.Exit_Ts))
                .ForMember(dest => dest.Record_Creation_Ts, opt => opt.MapFrom(source => source.Record_Creation_Ts))
                .ForMember(dest => dest.Entry_Ts, opt => opt.MapFrom(source => source.Entry_Ts))
                .ForMember(dest => dest.Last_Record_Update_Ts, opt => opt.MapFrom(source => source.Last_Record_Update_Ts));
     
        }
    }
}
