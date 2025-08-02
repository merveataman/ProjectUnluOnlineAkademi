using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.Blog.Queries.BlogGetList;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.ContactOptions.Queries.ContactOptionsGetList
{
    public class GetContactOptionsListQueryHandler : IRequestHandler<GetContactOptionsListQuery, List<ContactOptionsDto>>
    {
        private readonly IGenericRepository<Domain.Entities.ContactOptions> _repository;
        private readonly IMapper _mapper;

        public GetContactOptionsListQueryHandler(IGenericRepository<Domain.Entities.ContactOptions> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ContactOptionsDto>> Handle(GetContactOptionsListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<ContactOptionsDto>>(entities);
        }
    }
}
