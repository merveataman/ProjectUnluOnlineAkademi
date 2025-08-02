using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.SSS.Commands.CreateSSSCommand
{
    public class CreateSSSCommandHandler : IRequestHandler<CreateSSSCommand, Guid>
    {
        private readonly IGenericRepository<Domain.Entities.SSS> _repository;
        private readonly IMapper _mapper;

        public CreateSSSCommandHandler(IGenericRepository<Domain.Entities.SSS> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateSSSCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UnluOnlineAkademi.Domain.Entities.SSS>(request);
            var createdData = await _repository.AddAsync(entity);
            return createdData.ID;
        }
    }
}
