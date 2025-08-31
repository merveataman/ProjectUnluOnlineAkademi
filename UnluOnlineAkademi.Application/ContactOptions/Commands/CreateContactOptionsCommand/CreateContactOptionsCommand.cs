using MediatR;

namespace UnluOnlineAkademi.Application.ContactOptions.Commands.CreateContactOptionsCommand
{
    public class CreateContactOptionsCommand:IRequest<Guid>
    {
        public string Title { get; set; }
        public string? Icon { get; set; }
        public bool? Status { get; set; }
    }
}
