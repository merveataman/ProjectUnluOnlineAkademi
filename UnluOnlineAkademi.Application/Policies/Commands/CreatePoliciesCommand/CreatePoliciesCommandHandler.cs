using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Policies.Commands.CreatePoliciesCommand
{
    public class CreatePoliciesCommandHandler : IRequestHandler<CreatePoliciesCommand, Guid>
    {
        private readonly IGenericRepository<Domain.Entities.Policies> _repository;
        private readonly IMapper _mapper;

        public CreatePoliciesCommandHandler(IGenericRepository<Domain.Entities.Policies> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePoliciesCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UnluOnlineAkademi.Domain.Entities.Policies>(request);
            var createdData = await _repository.AddAsync(entity);
            return createdData.ID;
        }
    }
}