using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.CourseCategory.Queries.CourseCategoryById
{
    public class CourseCategoryByIdQueryHandler : IRequestHandler<CourseCategoryByIdQuery, CourseCategoryByIdDto>
    {
        private readonly IGenericRepository<Domain.Entities.CourseCategory> _repository;
        private readonly IMapper _mapper;

        public CourseCategoryByIdQueryHandler(IGenericRepository<Domain.Entities.CourseCategory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CourseCategoryByIdDto> Handle(CourseCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdAsync(request.ID);
            return _mapper.Map<CourseCategoryByIdDto>(entities);
        }
    }
}
