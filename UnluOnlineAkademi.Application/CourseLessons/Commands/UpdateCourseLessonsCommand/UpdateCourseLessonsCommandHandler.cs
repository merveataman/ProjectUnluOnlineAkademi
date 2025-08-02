using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.CourseLessons.Commands.UpdateCourseLessonsCommand
{
    public class UpdateCourseLessonsCommandHandler : IRequestHandler<UpdateCourseLessonsCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.CourseLessons> _repository;
        private readonly IMapper _mapper;

        public UpdateCourseLessonsCommandHandler(IGenericRepository<Domain.Entities.CourseLessons> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateCourseLessonsCommand request, CancellationToken cancellationToken)
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
