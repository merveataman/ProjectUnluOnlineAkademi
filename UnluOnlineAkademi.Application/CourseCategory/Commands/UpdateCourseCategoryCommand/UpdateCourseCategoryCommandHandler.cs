using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.CourseCategory.Commands.UpdateCourseCategoryCommand
{
    public class UpdateCourseCategoryCommandHandler : IRequestHandler<UpdateCourseCategoryCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.CourseCategory> _repository;
        private readonly IMapper _mapper;

        public UpdateCourseCategoryCommandHandler(IGenericRepository<Domain.Entities.CourseCategory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateCourseCategoryCommand request, CancellationToken cancellationToken)
        {
            var existingEntity = await _repository.GetByIdAsync(request.ID);
            if (existingEntity == null)
            {
                return false;
            }
            var entity = _mapper.Map(request, existingEntity);
            var updatedData = await _repository.UpdateAsync(entity);
            return true;
        }
    }
}
