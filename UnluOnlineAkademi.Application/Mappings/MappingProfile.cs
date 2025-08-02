using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.AboutUs.Commands.CreateAboutUsCommand;
using UnluOnlineAkademi.Application.AboutUs.Commands.DeleteAboutUsCommand;
using UnluOnlineAkademi.Application.AboutUs.Commands.UpdateAboutUsCommand;
using UnluOnlineAkademi.Application.AboutUs.Queries.AboutUsById;
using UnluOnlineAkademi.Application.AboutUs.Queries.AboutUsList;
using UnluOnlineAkademi.Application.MailList.Commands.CreateMailListCommand;
using UnluOnlineAkademi.Application.MailList.Commands.DeleteMailListCommand;
using UnluOnlineAkademi.Application.MailList.Commands.UpdateMailListCommand;
using UnluOnlineAkademi.Application.MailList.Queries.MailListById;
using UnluOnlineAkademi.Application.MailList.Queries.MailListList;
using UnluOnlineAkademi.Application.Policies.Commands.CreatePoliciesCommand;
using UnluOnlineAkademi.Application.Policies.Commands.DeletePoliciesCommand;
using UnluOnlineAkademi.Application.Policies.Commands.UpdatePoliciesCommand;
using UnluOnlineAkademi.Application.Policies.Queries.PoliciesById;
using UnluOnlineAkademi.Application.Policies.Queries.PoliciesList;
using UnluOnlineAkademi.Application.SSS.Commands.CreateSSSCommand;
using UnluOnlineAkademi.Application.SSS.Commands.DeleteSSSCommand;
using UnluOnlineAkademi.Application.SSS.Commands.UpdateSSSCommand;
using UnluOnlineAkademi.Application.SSS.Queries.SSSById;
using UnluOnlineAkademi.Application.SSS.Queries.SSSList;
using UnluOnlineAkademi.Application.StudentTestimonial.Commands.CreateStudentTestimonialCommand;
using UnluOnlineAkademi.Application.StudentTestimonial.Commands.DeleteStudentTestimonialCommand;
using UnluOnlineAkademi.Application.StudentTestimonial.Commands.UpdateStudentTestimonialCommand;
using UnluOnlineAkademi.Application.StudentTestimonial.Queries.StudentTestimonialById;
using UnluOnlineAkademi.Application.StudentTestimonial.Queries.StudentTestimonialList;
using UnluOnlineAkademi.Application.WhyUs.Commands.CreateWhyUsCommand;
using UnluOnlineAkademi.Application.WhyUs.Commands.DeleteWhyUsCommand;
using UnluOnlineAkademi.Application.WhyUs.Commands.UpdateWhyUsCommand;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsById;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsList;
using UnluOnlineAkademi.Domain.Entities;

namespace UnluOnlineAkademi.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UnluOnlineAkademi.Domain.Entities.AboutUs, AboutUsDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.AboutUs, AboutUsByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.AboutUs, CreateAboutUsCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.AboutUs, UpdateAboutUsCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.AboutUs, DeleteAboutUsCommand>().ReverseMap();

            CreateMap<UnluOnlineAkademi.Domain.Entities.WhyUs, WhyUsDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.WhyUs, WhyUsByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.WhyUs, CreateWhyUsCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.WhyUs, UpdateWhyUsCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.WhyUs, DeleteWhyUsCommand>().ReverseMap();

            CreateMap<UnluOnlineAkademi.Domain.Entities.StudentTestimonial, StudentTestimonialDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.StudentTestimonial, StudentTestimonialByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.StudentTestimonial, CreateStudentTestimonialCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.StudentTestimonial, UpdateStudentTestimonialCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.StudentTestimonial, DeleteStudentTestimonialCommand>().ReverseMap();

            CreateMap<UnluOnlineAkademi.Domain.Entities.SSS, SSSDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.SSS, SSSByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.SSS, CreateSSSCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.SSS, UpdateSSSCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.SSS, DeleteSSSCommand>().ReverseMap();


            CreateMap<UnluOnlineAkademi.Domain.Entities.Policies, PoliciesDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.Policies, PoliciesByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.Policies, CreatePoliciesCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.Policies, UpdatePoliciesCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.Policies, DeletePoliciesCommand>().ReverseMap();

            CreateMap<UnluOnlineAkademi.Domain.Entities.MailList, MailListDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.MailList, MailListByIdDto>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.MailList, CreateMailListCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.MailList, UpdateMailListCommand>().ReverseMap();
            CreateMap<UnluOnlineAkademi.Domain.Entities.MailList, DeleteMailListCommand>().ReverseMap();
        }
    }
}
