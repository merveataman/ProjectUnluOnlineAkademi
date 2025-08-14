using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.AboutUs.Commands.DeleteAboutUsCommand;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Header.Commands.DeleteHeaderCommand
{
    public class DeleteHeaderCommandHandler : IRequestHandler<DeleteHeaderCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.Header> _repository;
        private readonly IMapper _mapper;

        public DeleteHeaderCommandHandler(IGenericRepository<Domain.Entities.Header> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteHeaderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.ID);
            if (entity == null) { return false; }
            await _repository.DeleteAsync(entity.ID);
            return true;
        }
    }
}