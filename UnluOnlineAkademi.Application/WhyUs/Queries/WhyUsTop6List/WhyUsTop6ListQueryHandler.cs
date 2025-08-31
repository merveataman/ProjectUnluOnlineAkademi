using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsList;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsTop6List
{
    public class WhyUsTop6ListQueryHandler : IRequestHandler<WhyUsTop6ListQuery, List<WhyUsDto>>
    {
        private readonly IGenericRepository<Domain.Entities.WhyUs> _repository;
        private readonly IMapper _mapper;

        public WhyUsTop6ListQueryHandler(IGenericRepository<Domain.Entities.WhyUs> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<WhyUsDto>> Handle(WhyUsTop6ListQuery request, CancellationToken cancellationToken)
        {
            var all = await _repository.GetAllAsync();
            var top6 = all
                .OrderByDescending(x => x.CreatedDate)  // eğer yoksa: x => x.Id
                .Take(6)
                .ToList();

            return _mapper.Map<List<WhyUsDto>>(top6);
        }
    }
}
