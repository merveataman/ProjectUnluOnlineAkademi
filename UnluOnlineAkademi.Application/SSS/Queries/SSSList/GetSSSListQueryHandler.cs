using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.SSS.Queries.SSSList
{
    public class GetSSSListQueryHandler : IRequestHandler<GetSSSListQuery, List<SSSDto>>
    {
        private readonly IGenericRepository<Domain.Entities.SSS> _repository;
        private readonly IMapper _mapper;

        public GetSSSListQueryHandler(IGenericRepository<Domain.Entities.SSS> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<SSSDto>> Handle(GetSSSListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<SSSDto>>(entities);
        }
    }
}
