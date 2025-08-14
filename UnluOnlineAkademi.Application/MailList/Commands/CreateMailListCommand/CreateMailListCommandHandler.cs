using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.MailList.Commands.CreateMailListCommand
{
    public class CreateMailListCommandHandler : IRequestHandler<CreateMailListCommand, Guid>
    {
        private readonly IGenericRepository<Domain.Entities.MailList> _repository;
        private readonly IMapper _mapper;

        public CreateMailListCommandHandler(IGenericRepository<Domain.Entities.MailList> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateMailListCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UnluOnlineAkademi.Domain.Entities.MailList>(request);
            var createdData = await _repository.AddAsync(entity);
            return createdData.ID;
        }
    }
}
