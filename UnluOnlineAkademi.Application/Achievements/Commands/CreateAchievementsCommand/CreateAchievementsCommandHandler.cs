using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Achievements.Commands.CreateAchievementsCommand
{
    public class CreateAchievementsCommandHandler : IRequestHandler<CreateAchievementsCommand, Guid>
    {
        private readonly IGenericRepository<Domain.Entities.Achievements> _repository;
        private readonly IMapper _mapper;

        public CreateAchievementsCommandHandler(IGenericRepository<Domain.Entities.Achievements> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateAchievementsCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UnluOnlineAkademi.Domain.Entities.Achievements>(request);
            var createdData = await _repository.AddAsync(entity);
            return createdData.ID;
        }
    }
}
