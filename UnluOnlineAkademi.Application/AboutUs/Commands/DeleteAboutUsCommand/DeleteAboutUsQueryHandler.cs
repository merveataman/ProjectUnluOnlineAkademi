using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.AboutUs.Commands.DeleteAboutUsCommand
{
    public class DeleteAboutUsQueryHandler : IRequestHandler<DeleteAboutUsCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.AboutUs> _repository;
        private readonly IMapper _mapper;

        public DeleteAboutUsQueryHandler(IGenericRepository<Domain.Entities.AboutUs> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteAboutUsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.ID);
            if (entity == null) { return false; }
            await _repository.DeleteAsync(entity.ID);
            return true;
        }
    }
}
