using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.CourseLessons.Commands.CreateCourseLessonsCommand
{
    public class CreateCourseLessonsCommandHandler : IRequestHandler<CreateCourseLessonsCommand, Guid>
    {
        private readonly IGenericRepository<Domain.Entities.CourseLessons> _repository;
        private readonly IMapper _mapper;

        public CreateCourseLessonsCommandHandler(IGenericRepository<Domain.Entities.CourseLessons> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateCourseLessonsCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UnluOnlineAkademi.Domain.Entities.CourseLessons>(request);
            var createdData = await _repository.AddAsync(entity);
            return createdData.ID;
        }
    }
}
