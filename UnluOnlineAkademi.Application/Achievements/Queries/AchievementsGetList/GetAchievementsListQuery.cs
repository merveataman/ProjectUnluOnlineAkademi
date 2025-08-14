using MediatR;

namespace UnluOnlineAkademi.Application.Achievements.Queries.AchievementsGetList
{
    public class GetAchievementsListQuery : IRequest<List<AchievementsDto>>
    {
    }
}
