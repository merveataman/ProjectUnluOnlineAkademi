using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.ContactOptions.Commands.UpdateContactOptionsCommand
{
    internal class UpdateContactOptionsCommandHandler : IRequestHandler<UpdateContactOptionsCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.ContactOptions> _repository;
        private readonly IMapper _mapper;

        public UpdateContactOptionsCommandHandler(IGenericRepository<Domain.Entities.ContactOptions> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateContactOptionsCommand request, CancellationToken cancellationToken)
        {
            var existingEntity = await _repository.GetByIdAsync(request.ID);
            if (existingEntity == null)
            {
                return false;
            }
            var entity = _mapper.Map(request, existingEntity);
            var updatedData = await _repository.UpdateAsync(entity);
            return true;
        }
    }
}
