using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.ContactOptions.Queries.ContactOptionsById
{
    public class ContactOptionsByIdQueryHandler : IRequestHandler<ContactOptionsByIdQuery, ContactOptionsByIdDto>
    {
        private readonly IGenericRepository<Domain.Entities.ContactOptions> _repository;
        private readonly IMapper _mapper;

        public ContactOptionsByIdQueryHandler(IGenericRepository<Domain.Entities.ContactOptions> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ContactOptionsByIdDto> Handle(ContactOptionsByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdAsync(request.ID);
            return _mapper.Map<ContactOptionsByIdDto>(entities);
        }
    }
}
