using MediatR;

namespace UnluOnlineAkademi.Application.ContactInfo.Commands.CreateContactInfoCommand
{
    public class CreateContactInfoCommand : IRequest<Guid>
    {
        public string ContactInfo { get; set; }
        public bool? Status { get; set; }
    }
}
