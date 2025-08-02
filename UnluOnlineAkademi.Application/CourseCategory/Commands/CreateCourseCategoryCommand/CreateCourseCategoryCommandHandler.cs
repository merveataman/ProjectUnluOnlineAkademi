using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.CourseCategory.Commands.CreateCourseCategoryCommand
{
    public class CreateCourseCategoryCommandHandler : IRequestHandler<CreateCourseCategoryCommand, Guid>
    {
        private readonly IGenericRepository<Domain.Entities.CourseCategory> _repository;
        private readonly IMapper _mapper;

        public CreateCourseCategoryCommandHandler(IGenericRepository<Domain.Entities.CourseCategory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateCourseCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UnluOnlineAkademi.Domain.Entities.CourseCategory>(request);
            var createdData = await _repository.AddAsync(entity);
            return createdData.ID;
        }
    }
}
