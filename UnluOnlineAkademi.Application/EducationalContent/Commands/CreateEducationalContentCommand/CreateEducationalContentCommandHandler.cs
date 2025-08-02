using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.EducationalContent.Commands.CreateEducationalContentCommand
{
    public class CreateEducationalContentCommandHandler : IRequestHandler<CreateEducationalContentCommand, Guid>
    {
        private readonly IGenericRepository<Domain.Entities.EducationalContent> _repository;
        private readonly IMapper _mapper;

        public CreateEducationalContentCommandHandler(IGenericRepository<Domain.Entities.EducationalContent> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateEducationalContentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UnluOnlineAkademi.Domain.Entities.EducationalContent>(request);
            var createdData = await _repository.AddAsync(entity);
            return createdData.ID;
        }
    }
}
