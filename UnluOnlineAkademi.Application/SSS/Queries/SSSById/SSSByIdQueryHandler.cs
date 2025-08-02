using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsById;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.SSS.Queries.SSSById
{
    public class SSSByIdQueryHandler : IRequestHandler<SSSByIdQuery, SSSByIdDto>
    {
        private readonly IGenericRepository<Domain.Entities.SSS> _repository;
        private readonly IMapper _mapper;

        public SSSByIdQueryHandler(IGenericRepository<Domain.Entities.SSS> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SSSByIdDto> Handle(SSSByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdAsync(request.ID);
            return _mapper.Map<SSSByIdDto>(entities);
        }
    }
}
