using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.ContactInfo.Commands.DeleteContactInfoCommand
{
    public class DeleteContactInfoCommandHandler : IRequestHandler<DeleteContactInfoCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.ContactInfos> _repository;
        private readonly IMapper _mapper;

        public DeleteContactInfoCommandHandler(IGenericRepository<Domain.Entities.ContactInfos> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteContactInfoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.ID);
            if (entity == null) { return false; }
            await _repository.DeleteAsync(entity.ID);
            return true;
        }
    }
}
