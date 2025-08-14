using MediatR;

namespace UnluOnlineAkademi.Application.CourseLessons.Queries.CourseLessonsById
{
    public class CourseLessonsByIdQuery : IRequest<CourseLessonsByIdDto>
    {
        public Guid ID { get; set; }
    }
}
