using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Policies.Queries.PoliciesById
{
    public class PoliciesByIdQueryHandler : IRequestHandler<PoliciesByIdQuery, PoliciesByIdDto>
    {
        private readonly IGenericRepository<Domain.Entities.Policies> _repository;
        private readonly IMapper _mapper;

        public PoliciesByIdQueryHandler(IGenericRepository<Domain.Entities.Policies> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PoliciesByIdDto> Handle(PoliciesByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdAsync(request.ID);
            return _mapper.Map<PoliciesByIdDto>(entities);
        }
    }
}
