using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.EducationalContent.Commands.DeleteEducationalContentCommand
{
    public class DeleteEducationalContentCommandHandler : IRequestHandler<DeleteEducationalContentCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.EducationalContent> _repository;
        private readonly IMapper _mapper;

        public DeleteEducationalContentCommandHandler(IGenericRepository<Domain.Entities.EducationalContent> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteEducationalContentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.ID);
            if (entity == null) { return false; }
            await _repository.DeleteAsync(entity.ID);
            return true;
        }
    }
}
