using MediatR;

namespace UnluOnlineAkademi.Application.ContactOptions.Commands.DeleteContactOptionsCommand
{
    public class DeleteContactOptionsCommand : IRequest<bool>
    {
        public Guid ID { get; set; }

        public DeleteContactOptionsCommand(Guid id)
        {
            ID = id;
        }
    }
}
