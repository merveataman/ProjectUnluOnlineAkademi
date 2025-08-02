using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.SSS.Commands.UpdateSSSCommand
{
    public class UpdateSSSCommandHandler : IRequestHandler<UpdateSSSCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.SSS> _repository;
        private readonly IMapper _mapper;

        public UpdateSSSCommandHandler(IGenericRepository<Domain.Entities.SSS> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateSSSCommand request, CancellationToken cancellationToken)
        {
            var existingEntity = await _repository.GetByIdAsync(request.ID);
            if (existingEntity == null)
            {
                return false;
            }
            var entity = _mapper.Map(request, existingEntity);
            var updatedData = await _repository.UpdateAsync(entity);
            return true;
        }
    }
}
