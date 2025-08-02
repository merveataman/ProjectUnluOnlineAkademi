using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.WhyUs.Commands.CreateWhyUsCommand
{
    public class CreateWhyUsCommandHandler : IRequestHandler<CreateWhyUsCommand, Guid>
    {
        private readonly IGenericRepository<Domain.Entities.WhyUs> _repository;
        private readonly IMapper _mapper;

        public CreateWhyUsCommandHandler(IGenericRepository<Domain.Entities.WhyUs> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateWhyUsCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UnluOnlineAkademi.Domain.Entities.WhyUs>(request);
            var createdData = await _repository.AddAsync(entity);
            return createdData.ID;
        }
    }
}