using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.AboutUs.Commands.UpdateAboutUsCommand;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Header.Commands.UpdateHeaderCommand
{
    public class UpdateHeaderCommandHandler : IRequestHandler<UpdateHeaderCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.Header> _repository;
        private readonly IMapper _mapper;

        public UpdateHeaderCommandHandler(IGenericRepository<Domain.Entities.Header> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateHeaderCommand request, CancellationToken cancellationToken)
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
