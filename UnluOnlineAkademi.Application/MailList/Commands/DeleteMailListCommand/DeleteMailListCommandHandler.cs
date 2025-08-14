using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.SSS.Commands.DeleteSSSCommand;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.MailList.Commands.DeleteMailListCommand
{
    public class DeleteMailListCommandHandler : IRequestHandler<DeleteMailListCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.MailList> _repository;
        private readonly IMapper _mapper;

        public DeleteMailListCommandHandler(IGenericRepository<Domain.Entities.MailList> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteMailListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.ID);
            if (entity == null) { return false; }
            await _repository.DeleteAsync(entity.ID);
            return true;
        }
    }
}
