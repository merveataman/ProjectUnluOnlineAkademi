using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.AboutUs.Commands.CreateAboutUsCommand;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.AboutUs.Commands.UpdateAboutUsCommand
{
    public class UpdateAboutUsQueryHandler : IRequestHandler<UpdateAboutUsCommand, UpdateAboutUsDto>
    {
        private readonly IGenericRepository<Domain.Entities.AboutUs> _repository;
        private readonly IMapper _mapper;

        public UpdateAboutUsQueryHandler(IGenericRepository<Domain.Entities.AboutUs> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UpdateAboutUsDto> Handle(UpdateAboutUsCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UnluOnlineAkademi.Domain.Entities.AboutUs>(request);
            var updatedData = await _repository.UpdateAsync(entity);
            var dto = _mapper.Map<UpdateAboutUsDto>(updatedData);
            return dto;
        }
    }
}
