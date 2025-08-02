using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.MailList.Queries.MailListList
{
    public class MailListListQueryHandler : IRequestHandler<GetMailListListQuery, List<MailListDto>>
    {
        private readonly IGenericRepository<Domain.Entities.MailList> _repository;
        private readonly IMapper _mapper;

        public MailListListQueryHandler(IGenericRepository<Domain.Entities.MailList> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MailListDto>> Handle(GetMailListListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<MailListDto>>(entities);
        }
    }
}
