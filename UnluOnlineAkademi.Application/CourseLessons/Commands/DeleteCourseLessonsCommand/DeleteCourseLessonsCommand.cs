using MediatR;

namespace UnluOnlineAkademi.Application.CourseLessons.Commands.DeleteCourseLessonsCommand
{
    public class DeleteCourseLessonsCommand : IRequest<bool>
    {
        public Guid ID { get; set; }
        public DeleteCourseLessonsCommand(Guid id)
        {
            ID = id;
        }
    }
}
