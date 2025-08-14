using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.SSS.Commands.DeleteSSSCommand
{
    public class DeleteSSSCommandHandler : IRequestHandler<DeleteSSSCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.SSS> _repository;
        private readonly IMapper _mapper;

        public DeleteSSSCommandHandler(IGenericRepository<Domain.Entities.SSS> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteSSSCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.ID);
            if (entity == null) { return false; }
            await _repository.DeleteAsync(entity.ID);
            return true;
        }
    }
}
