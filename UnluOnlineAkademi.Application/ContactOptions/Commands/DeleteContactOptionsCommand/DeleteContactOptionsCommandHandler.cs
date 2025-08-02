using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.ContactOptions.Commands.DeleteContactOptionsCommand
{
    internal class DeleteContactOptionsCommandHandler : IRequestHandler<DeleteContactOptionsCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.ContactOptions> _repository;
        private readonly IMapper _mapper;

        public DeleteContactOptionsCommandHandler(IGenericRepository<Domain.Entities.ContactOptions> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteContactOptionsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.ID);
            if (entity == null) { return false; }
            await _repository.DeleteAsync(entity.ID);
            return true;
        }
    }
}
