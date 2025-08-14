using MediatR;

namespace UnluOnlineAkademi.Application.AboutUs.Commands.UpdateAboutUsCommand
{
    public class UpdateAboutUsCommand : IRequest<bool>
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string? Image { get; set; }
        public bool? Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
