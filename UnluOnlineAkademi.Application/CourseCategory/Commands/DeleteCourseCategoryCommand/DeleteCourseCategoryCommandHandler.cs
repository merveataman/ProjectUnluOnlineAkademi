using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.CourseCategory.Commands.DeleteCourseCategoryCommand
{
    public class DeleteCourseCategoryCommandHandler : IRequestHandler<DeleteCourseCategoryCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.CourseCategory> _repository;
        private readonly IMapper _mapper;

        public DeleteCourseCategoryCommandHandler(IGenericRepository<Domain.Entities.CourseCategory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteCourseCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.ID);
            if (entity == null) { return false; }
            await _repository.DeleteAsync(entity.ID);
            return true;
        }
    }
}
