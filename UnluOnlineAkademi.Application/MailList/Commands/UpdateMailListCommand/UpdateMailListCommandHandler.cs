using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.SSS.Commands.UpdateSSSCommand;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.MailList.Commands.UpdateMailListCommand
{
    public class UpdateMailListCommandHandler : IRequestHandler<UpdateMailListCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.MailList> _repository;
        private readonly IMapper _mapper;

        public UpdateMailListCommandHandler(IGenericRepository<Domain.Entities.MailList> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateMailListCommand request, CancellationToken cancellationToken)
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
