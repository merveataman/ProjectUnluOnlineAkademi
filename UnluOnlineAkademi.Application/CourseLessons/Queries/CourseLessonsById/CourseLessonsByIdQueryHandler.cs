using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.CourseLessons.Queries.CourseLessonsById
{
    public class CourseLessonsByIdQueryHandler : IRequestHandler<CourseLessonsByIdQuery, CourseLessonsByIdDto>
    {
        private readonly IGenericRepository<Domain.Entities.CourseLessons> _repository;
        private readonly IMapper _mapper;

        public CourseLessonsByIdQueryHandler(IGenericRepository<Domain.Entities.CourseLessons> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CourseLessonsByIdDto> Handle(CourseLessonsByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdAsync(request.ID);
            return _mapper.Map<CourseLessonsByIdDto>(entities);
        }
    }
}
