using MediatR;

namespace UnluOnlineAkademi.Application.CourseLessons.Queries.CourseLessonsGetList
{
    public class GetCourseLessonsListQuery:IRequest<List<CourseLessonsDto>>
    {
    }
}
