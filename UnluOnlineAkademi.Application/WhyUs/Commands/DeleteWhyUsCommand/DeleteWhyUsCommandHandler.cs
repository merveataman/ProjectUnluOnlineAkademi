using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.AboutUs.Commands.DeleteAboutUsCommand;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.WhyUs.Commands.DeleteWhyUsCommand
{
    public class DeleteWhyUsCommandHandler : IRequestHandler<DeleteWhyUsCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.WhyUs> _repository;
        private readonly IMapper _mapper;

        public DeleteWhyUsCommandHandler(IGenericRepository<Domain.Entities.WhyUs> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteWhyUsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.ID);
            if (entity == null) { return false; }
            await _repository.DeleteAsync(entity.ID);
            return true;
        }
    }
}