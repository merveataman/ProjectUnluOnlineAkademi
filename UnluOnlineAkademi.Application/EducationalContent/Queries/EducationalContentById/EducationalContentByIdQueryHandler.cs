using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.EducationalContent.Queries.EducationalContentById
{
    internal class EducationalContentByIdQueryHandler : IRequestHandler<EducationalContentByIdQuery, EducationalContentByIdDto>
    {
        private readonly IGenericRepository<Domain.Entities.EducationalContent> _repository;
        private readonly IMapper _mapper;

        public EducationalContentByIdQueryHandler(IGenericRepository<Domain.Entities.EducationalContent> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<EducationalContentByIdDto> Handle(EducationalContentByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdAsync(request.ID);
            return _mapper.Map<EducationalContentByIdDto>(entities);
        }
    }
}
