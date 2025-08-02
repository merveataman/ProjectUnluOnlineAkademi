using MediatR;

namespace UnluOnlineAkademi.Application.CourseCategory.Commands.DeleteCourseCategoryCommand
{
    public class DeleteCourseCategoryCommand : IRequest<bool>
    {
        public Guid ID { get; set; }

        public DeleteCourseCategoryCommand(Guid id)
        {
            ID = id;
        }
    }
}
