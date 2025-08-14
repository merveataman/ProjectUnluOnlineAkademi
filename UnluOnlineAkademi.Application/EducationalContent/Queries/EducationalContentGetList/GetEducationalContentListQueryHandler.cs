using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.EducationalContent.Queries.EducationalContentGetList
{
    public class GetEducationalContentListQueryHandler : IRequestHandler<GetEducationalContentListQuery, List<EducationalContentDto>>
    {
        private readonly IGenericRepository<Domain.Entities.EducationalContent> _repository;
        private readonly IMapper _mapper;

        public GetEducationalContentListQueryHandler(IGenericRepository<Domain.Entities.EducationalContent> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<EducationalContentDto>> Handle(GetEducationalContentListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<EducationalContentDto>>(entities);
        }
    }
}
