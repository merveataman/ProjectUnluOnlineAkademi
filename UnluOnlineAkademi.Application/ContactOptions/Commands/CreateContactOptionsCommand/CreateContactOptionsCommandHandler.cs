using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.ContactOptions.Commands.CreateContactOptionsCommand
{
    public class CreateContactOptionsCommandHandler : IRequestHandler<CreateContactOptionsCommand, Guid>
    {
        private readonly IGenericRepository<Domain.Entities.ContactOptions> _repository;
        private readonly IMapper _mapper;

        public CreateContactOptionsCommandHandler(IGenericRepository<Domain.Entities.ContactOptions> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateContactOptionsCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UnluOnlineAkademi.Domain.Entities.ContactOptions>(request);
            var createdData = await _repository.AddAsync(entity);
            return createdData.ID;
        }
    }
}
