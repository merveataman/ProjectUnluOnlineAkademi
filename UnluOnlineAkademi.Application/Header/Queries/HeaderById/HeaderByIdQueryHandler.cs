using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.AboutUs.Queries.AboutUsById;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Header.Queries.HeaderById
{
    public class HeaderByIdQueryHandler : IRequestHandler<HeaderByIdQuery, HeaderByIdDto>
    {
        private readonly IGenericRepository<Domain.Entities.Header> _repository;
        private readonly IMapper _mapper;

        public HeaderByIdQueryHandler(IGenericRepository<Domain.Entities.Header> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<HeaderByIdDto> Handle(HeaderByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdAsync(request.ID);
            return _mapper.Map<HeaderByIdDto>(entities);
        }
    }
}
