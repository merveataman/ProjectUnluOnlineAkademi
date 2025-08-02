using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Entities;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.AboutUs.Commands.CreateAboutUsCommand
{
    public class CreateAboutUsCommandHandler : IRequestHandler<CreateAboutUsCommand, Guid>
    {
        private readonly IGenericRepository<Domain.Entities.AboutUs> _repository;
        private readonly IMapper _mapper;

        public CreateAboutUsCommandHandler(IGenericRepository<Domain.Entities.AboutUs> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateAboutUsCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UnluOnlineAkademi.Domain.Entities.AboutUs>(request);
            var createdData = await _repository.AddAsync(entity);
            return createdData.ID;
        }
    }
}
