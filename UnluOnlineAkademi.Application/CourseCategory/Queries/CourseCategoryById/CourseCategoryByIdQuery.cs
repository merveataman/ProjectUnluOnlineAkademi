using MediatR;

namespace UnluOnlineAkademi.Application.CourseCategory.Queries.CourseCategoryById
{
    public class CourseCategoryByIdQuery : IRequest<CourseCategoryByIdDto>
    {
        public Guid ID { get; set; }
    }
}
