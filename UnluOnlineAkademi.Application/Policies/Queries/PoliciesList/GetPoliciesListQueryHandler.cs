using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.SSS.Queries.SSSList;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Policies.Queries.PoliciesList
{
    public class GetPoliciesListQueryHandler : IRequestHandler<GetPoliciesListQuery, List<PoliciesDto>>
    {
        private readonly IGenericRepository<Domain.Entities.Policies> _repository;
        private readonly IMapper _mapper;

        public GetPoliciesListQueryHandler(IGenericRepository<Domain.Entities.Policies> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PoliciesDto>> Handle(GetPoliciesListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<PoliciesDto>>(entities);
        }
    }
}
