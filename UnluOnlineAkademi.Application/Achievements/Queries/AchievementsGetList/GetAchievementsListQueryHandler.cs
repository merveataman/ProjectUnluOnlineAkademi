using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Achievements.Queries.AchievementsGetList
{
    public class GetAchievementsListQueryHandler : IRequestHandler<GetAchievementsListQuery, List<AchievementsDto>>
    {

        private readonly IGenericRepository<Domain.Entities.Achievements> _repository;
        private readonly IMapper _mapper;

        public GetAchievementsListQueryHandler(IGenericRepository<Domain.Entities.Achievements> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<AchievementsDto>> Handle(GetAchievementsListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<AchievementsDto>>(entities);
        }
    }
}
