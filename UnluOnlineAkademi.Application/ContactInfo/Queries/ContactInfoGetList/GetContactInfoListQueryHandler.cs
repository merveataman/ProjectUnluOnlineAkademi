using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.ContactInfo.Queries.ContactInfoGetList
{
    public class GetContactInfoListQueryHandler : IRequestHandler<GetContactInfoListQuery, List<ContactInfoDto>>
    {
        private readonly IGenericRepository<Domain.Entities.ContactInfos> _repository;
        private readonly IMapper _mapper;

        public GetContactInfoListQueryHandler(IGenericRepository<Domain.Entities.ContactInfos> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ContactInfoDto>> Handle(GetContactInfoListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<ContactInfoDto>>(entities);
        }
    }
}
