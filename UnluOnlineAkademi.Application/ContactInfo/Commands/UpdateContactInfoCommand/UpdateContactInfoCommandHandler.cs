using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.ContactInfo.Commands.UpdateContactInfoCommand
{
    public class UpdateContactInfoCommandHandler : IRequestHandler<UpdateContactInfoCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.ContactInfos> _repository;
        private readonly IMapper _mapper;

        public UpdateContactInfoCommandHandler(IGenericRepository<Domain.Entities.ContactInfos> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
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
