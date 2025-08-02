using MediatR;

namespace UnluOnlineAkademi.Application.EducationalContent.Commands.DeleteEducationalContentCommand
{
    public class DeleteEducationalContentCommand : IRequest<bool>
    {
        public Guid ID { get; set; }
        public DeleteEducationalContentCommand(Guid id)
        {
            ID = id;
        }
    }
}
