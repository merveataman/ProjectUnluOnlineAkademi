using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.AboutUs.Queries;
using UnluOnlineAkademi.Domain.Entities;

namespace UnluOnlineAkademi.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UnluOnlineAkademi.Domain.Entities.AboutUs, AboutUsDto>().ReverseMap();
        }
    }
}
