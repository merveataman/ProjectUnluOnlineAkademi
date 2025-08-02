using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.CourseLessons.Commands.DeleteCourseLessonsCommand
{
    public class DeleteCourseLessonsCommandHandler : IRequestHandler<DeleteCourseLessonsCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.CourseLessons> _repository;
        private readonly IMapper _mapper;

        public DeleteCourseLessonsCommandHandler(IGenericRepository<Domain.Entities.CourseLessons> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteCourseLessonsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.ID);
            if (entity == null) { return false; }
            await _repository.DeleteAsync(entity.ID);
            return true;
        }
    }
}
