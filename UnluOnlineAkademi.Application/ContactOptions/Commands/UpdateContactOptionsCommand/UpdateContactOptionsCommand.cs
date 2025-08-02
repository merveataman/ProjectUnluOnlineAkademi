using MediatR;

namespace UnluOnlineAkademi.Application.ContactOptions.Commands.UpdateContactOptionsCommand
{
    public class UpdateContactOptionsCommand:IRequest<bool>
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public bool? Status { get; set; }
    }
}
