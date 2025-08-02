using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.SSS.Queries.SSSById;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.MailList.Queries.MailListById
{
    public class MailListByIdQueryHandller : IRequestHandler<MailListByIdQuery, MailListByIdDto>
    {
        private readonly IGenericRepository<Domain.Entities.MailList> _repository;
        private readonly IMapper _mapper;

        public MailListByIdQueryHandller(IGenericRepository<Domain.Entities.MailList> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MailListByIdDto> Handle(MailListByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdAsync(request.ID);
            return _mapper.Map<MailListByIdDto>(entities);
        }
    }
}
