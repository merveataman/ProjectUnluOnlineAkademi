using MediatR;

namespace UnluOnlineAkademi.Application.CourseCategory.Commands.UpdateCourseCategoryCommand
{
    public class UpdateCourseCategoryCommand : IRequest<bool>
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public bool? Status { get; set; }
    }
}
