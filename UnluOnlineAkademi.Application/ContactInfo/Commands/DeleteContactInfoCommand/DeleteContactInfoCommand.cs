using MediatR;

namespace UnluOnlineAkademi.Application.ContactInfo.Commands.DeleteContactInfoCommand
{
    public class DeleteContactInfoCommand : IRequest<bool>
    {
        public Guid ID { get; set; }
        public DeleteContactInfoCommand(Guid id)
        {
            ID = id;
        }
    }
}
