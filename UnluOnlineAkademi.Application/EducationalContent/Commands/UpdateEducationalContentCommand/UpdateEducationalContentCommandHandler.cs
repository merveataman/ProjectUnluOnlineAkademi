using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.EducationalContent.Commands.UpdateEducationalContentCommand
{
    internal class UpdateEducationalContentCommandHandler : IRequestHandler<UpdateEducationalContentCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.EducationalContent> _repository;
        private readonly IMapper _mapper;

        public UpdateEducationalContentCommandHandler(IGenericRepository<Domain.Entities.EducationalContent> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateEducationalContentCommand request, CancellationToken cancellationToken)
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
