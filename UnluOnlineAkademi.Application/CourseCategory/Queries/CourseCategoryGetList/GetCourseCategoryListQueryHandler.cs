using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.CourseCategory.Queries.CourseCategoryGetList
{
    public class GetCourseCategoryListQueryHandler : IRequestHandler<GetCourseCategoryListQuery, List<CourseCategoryDto>>
    {
        private readonly IGenericRepository<Domain.Entities.CourseCategory> _repository;
        private readonly IMapper _mapper;

        public GetCourseCategoryListQueryHandler(IGenericRepository<Domain.Entities.CourseCategory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CourseCategoryDto>> Handle(GetCourseCategoryListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<CourseCategoryDto>>(entities); ;
        }
    }
}
