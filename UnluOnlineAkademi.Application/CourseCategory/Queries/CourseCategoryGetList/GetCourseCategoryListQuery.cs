using MediatR;

namespace UnluOnlineAkademi.Application.CourseCategory.Queries.CourseCategoryGetList
{
    public class GetCourseCategoryListQuery:IRequest<List<CourseCategoryDto>>
    {
    }
}
