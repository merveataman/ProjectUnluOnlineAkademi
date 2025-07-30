using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Entities;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.AboutUs.Queries
{
    public class GetAboutUsListQueryHandler : IRequestHandler<GetAboutUsListQuery, List<AboutUsDto>>
    {
        private readonly IGenericRepository<UnluOnlineAkademi.Domain.Entities.AboutUs> _repository;
        private readonly IMapper _mapper;
        public async Task<List<AboutUsDto>> Handle(GetAboutUsListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<AboutUsDto>>(entities);
        }
    }
}
