using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.AboutUs.Commands.CreateAboutUsCommand;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Header.Commands.CreateHeaderCommand
{
    public class CreateHeaderCommandHandler : IRequestHandler<CreateHeaderCommand, Guid>
    {
        private readonly IGenericRepository<Domain.Entities.Header> _repository;
        private readonly IMapper _mapper;

        public CreateHeaderCommandHandler(IGenericRepository<Domain.Entities.Header> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateHeaderCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UnluOnlineAkademi.Domain.Entities.Header>(request);
            var createdData = await _repository.AddAsync(entity);
            return createdData.ID;
        }
    }
}