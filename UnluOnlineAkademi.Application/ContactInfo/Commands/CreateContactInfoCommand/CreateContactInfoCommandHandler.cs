using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.ContactInfo.Commands.CreateContactInfoCommand
{
    public class CreateContactInfoCommandHandler : IRequestHandler<CreateContactInfoCommand, Guid>
    {
        private readonly IGenericRepository<Domain.Entities.ContactInfos> _repository;
        private readonly IMapper _mapper;

        public CreateContactInfoCommandHandler(IGenericRepository<Domain.Entities.ContactInfos> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UnluOnlineAkademi.Domain.Entities.ContactInfos>(request);
            var createdData = await _repository.AddAsync(entity);
            return createdData.ID;
        }
    }
}
