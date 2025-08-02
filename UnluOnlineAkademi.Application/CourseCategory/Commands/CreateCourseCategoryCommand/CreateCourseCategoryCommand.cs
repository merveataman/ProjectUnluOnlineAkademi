using MediatR;

namespace UnluOnlineAkademi.Application.CourseCategory.Commands.CreateCourseCategoryCommand
{
    public class CreateCourseCategoryCommand:IRequest<Guid>
    {
        public string Title { get; set; }
        public bool? Status { get; set; }
    }
}
