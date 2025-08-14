using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.AboutUs.Queries.AboutUsList;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsList
{
    public class GetWhyUsListQueryHandler : IRequestHandler<GetWhyUsListQuery, List<WhyUsDto>>
    {
        private readonly IGenericRepository<Domain.Entities.WhyUs> _repository;
        private readonly IMapper _mapper;

        public GetWhyUsListQueryHandler(IGenericRepository<Domain.Entities.WhyUs> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<WhyUsDto>> Handle(GetWhyUsListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<WhyUsDto>>(entities);
        }
    }
}
