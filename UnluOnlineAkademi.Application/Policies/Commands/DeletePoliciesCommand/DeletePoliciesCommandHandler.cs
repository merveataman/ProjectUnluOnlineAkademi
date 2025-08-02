using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Policies.Commands.DeletePoliciesCommand
{
    public class DeletePoliciesCommandHandler : IRequestHandler<DeletePoliciesCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.Policies> _repository;
        private readonly IMapper _mapper;

        public DeletePoliciesCommandHandler(IGenericRepository<Domain.Entities.Policies> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeletePoliciesCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.ID);
            if (entity == null) { return false; }
            await _repository.DeleteAsync(entity.ID);
            return true;
        }
    }
}
