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
    public class CreateAboutUsQueryHandler : IRequestHandler<CreateAboutUsCommand, CreateAboutUsDto>
    {
        private readonly IGenericRepository<Domain.Entities.AboutUs> _repository;
        private readonly IMapper _mapper;

        public CreateAboutUsQueryHandler(IGenericRepository<Domain.Entities.AboutUs> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CreateAboutUsDto> Handle(CreateAboutUsCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UnluOnlineAkademi.Domain.Entities.AboutUs>(request);
            var createdData = await _repository.AddAsync(entity);
            var dto = _mapper.Map<CreateAboutUsDto>(createdData);
            return dto;
        }
    }
}
