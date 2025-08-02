using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.AboutUs.Queries.AboutUsById;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Achievements.Queries.AchievementsById
{
    public class AchievementsByIdQueryHandler : IRequestHandler<AchievementsByIdQuery, AchievementsByIdDto>
    {
        private readonly IGenericRepository<Domain.Entities.Achievements> _repository;
        private readonly IMapper _mapper;

        public AchievementsByIdQueryHandler(IGenericRepository<Domain.Entities.Achievements> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AchievementsByIdDto> Handle(AchievementsByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdAsync(request.ID);
            return _mapper.Map<AchievementsByIdDto>(entities);
        }
    }
}
