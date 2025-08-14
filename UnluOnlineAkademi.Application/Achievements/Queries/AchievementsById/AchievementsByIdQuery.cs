using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.Achievements.Queries.AchievementsById
{
    public class AchievementsByIdQuery : IRequest<AchievementsByIdDto>
    {
        public Guid ID { get; set; }
    }
}
