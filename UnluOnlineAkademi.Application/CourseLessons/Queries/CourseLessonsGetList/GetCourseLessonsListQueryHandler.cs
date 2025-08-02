using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.CourseLessons.Queries.CourseLessonsGetList
{
    public class GetCourseLessonsListQueryHandler : IRequestHandler<GetCourseLessonsListQuery, List<CourseLessonsDto>>
    {
        private readonly IGenericRepository<Domain.Entities.CourseLessons> _repository;
        private readonly IMapper _mapper;

        public GetCourseLessonsListQueryHandler(IGenericRepository<Domain.Entities.CourseLessons> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<CourseLessonsDto>> Handle(GetCourseLessonsListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<CourseLessonsDto>>(entities);
        }
    }
}
