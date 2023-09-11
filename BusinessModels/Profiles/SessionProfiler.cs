using AutoMapper;
using DataModels;
using Newtonsoft.Json;
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
            CreateMap<UserSession, Session>();

            CreateMap<Session, UserSession>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
              .ForMember(dest => dest.Record_Creation_Ts, opt => opt.MapFrom(src => src.Record_Creation_Ts))
              .ForMember(dest => dest.Last_Record_Update_Ts, opt => opt.MapFrom(src => src.Last_Record_Update_Ts))
              //.ForMember(dest => dest.Paths, opt => opt.MapFrom<PathsToPathItemResolver>())
              .ForMember(dest => dest.Paths, opt => opt.MapFrom(src => src.Paths))
              .ForMember(dest => dest.Entry_Ts, opt => opt.MapFrom(src => src.Entry_Ts))
              .ForMember(dest => dest.Exit_Ts, opt => opt.MapFrom(src => src.Exit_Ts));

            CreateMap<Session, UserSessionQuote>()
           .ForMember(dest => dest.Entry_Ts, opt => opt.MapFrom(src => src.Entry_Ts))
           .ForMember(dest => dest.Exit_Ts, opt => opt.MapFrom(src => src.Exit_Ts))
           .ForMember(dest => dest.Last_Record_Update_Ts, opt => opt.MapFrom(src => src.Last_Record_Update_Ts))
           .ForMember(dest => dest.Record_Creation_Ts, opt => opt.MapFrom(src => src.Record_Creation_Ts))
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
