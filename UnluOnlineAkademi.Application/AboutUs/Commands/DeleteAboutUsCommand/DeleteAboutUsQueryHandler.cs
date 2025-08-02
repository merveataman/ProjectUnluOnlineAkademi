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
    public class DeleteAboutUsQueryHandler : IRequestHandler<DeleteAboutUsCommand, DeleteAboutUsDto>
    {
        private readonly IGenericRepository<Domain.Entities.AboutUs> _repository;
        private readonly IMapper _mapper;

        public DeleteAboutUsQueryHandler(IGenericRepository<Domain.Entities.AboutUs> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<DeleteAboutUsDto> Handle(DeleteAboutUsCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.ID);

            return new DeleteAboutUsDto { ID = request.ID };
        }
    }
}
