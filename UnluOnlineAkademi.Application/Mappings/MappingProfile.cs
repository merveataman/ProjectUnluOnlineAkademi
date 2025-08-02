using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.AboutUs.Commands.CreateAboutUsCommand;
using UnluOnlineAkademi.Application.AboutUs.Commands.DeleteAboutUsCommand;
using UnluOnlineAkademi.Application.AboutUs.Commands.UpdateAboutUsCommand;
using UnluOnlineAkademi.Application.AboutUs.Queries.AboutUsList;
using UnluOnlineAkademi.Domain.Entities;

namespace UnluOnlineAkademi.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UnluOnlineAkademi.Domain.Entities.AboutUs, AboutUsDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.AboutUs, CreateAboutUsDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.AboutUs, UpdateAboutUsDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.AboutUs, DeleteAboutUsDto>().ReverseMap();
        }
    }
}
