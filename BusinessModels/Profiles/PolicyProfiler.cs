using AutoMapper;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels.Profiles
{
    public class PolicyProfiler : Profile
    {
        public PolicyProfiler() {
            CreateMap<Policy, DataModels.Policy>();

            CreateMap<DataModels.Policy,Policy>();
        }
    }
}
