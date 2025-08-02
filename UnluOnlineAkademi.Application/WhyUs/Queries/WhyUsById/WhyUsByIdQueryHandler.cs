using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsById
{
    public class WhyUsByIdQueryHandler : IRequestHandler<WhyUsByIdQuery, WhyUsByIdDto>
    {
        private readonly IGenericRepository<Domain.Entities.WhyUs> _repository;
        private readonly IMapper _mapper;

        public WhyUsByIdQueryHandler(IGenericRepository<Domain.Entities.WhyUs> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WhyUsByIdDto> Handle(WhyUsByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdAsync(request.ID);
            return _mapper.Map<WhyUsByIdDto>(entities);
        }
    }
}
