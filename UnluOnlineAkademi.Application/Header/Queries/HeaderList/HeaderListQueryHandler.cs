using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.AboutUs.Queries.AboutUsList;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Header.Queries.HeaderList
{
    public class HeaderListQueryHandler : IRequestHandler<HeaderListQuery, List<HeaderDto>>
    {
        private readonly IGenericRepository<Domain.Entities.Header> _repository;
        private readonly IMapper _mapper;

        public HeaderListQueryHandler(IGenericRepository<Domain.Entities.Header> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<HeaderDto>> Handle(HeaderListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<HeaderDto>>(entities);
        }
    }
}
