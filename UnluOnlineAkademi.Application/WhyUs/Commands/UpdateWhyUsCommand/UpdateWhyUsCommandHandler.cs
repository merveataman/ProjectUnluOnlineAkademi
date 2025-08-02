using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.WhyUs.Commands.UpdateWhyUsCommand
{
    public class UpdateWhyUsCommandHandler : IRequestHandler<UpdateWhyUsCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.WhyUs> _repository;
        private readonly IMapper _mapper;

        public UpdateWhyUsCommandHandler(IGenericRepository<Domain.Entities.WhyUs> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateWhyUsCommand request, CancellationToken cancellationToken)
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