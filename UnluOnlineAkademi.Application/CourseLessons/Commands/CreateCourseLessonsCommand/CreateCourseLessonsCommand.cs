using MediatR;

namespace UnluOnlineAkademi.Application.CourseLessons.Commands.CreateCourseLessonsCommand
{
    public class CreateCourseLessonsCommand:IRequest<Guid>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Icon { get; set; }
        public string? BackgroundHexColor { get; set; }
        public bool? Status { get; set; }
    }
}
