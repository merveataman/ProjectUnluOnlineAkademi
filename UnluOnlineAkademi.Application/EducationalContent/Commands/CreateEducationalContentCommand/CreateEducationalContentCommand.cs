using MediatR;

namespace UnluOnlineAkademi.Application.EducationalContent.Commands.CreateEducationalContentCommand
{
    public class CreateEducationalContentCommand : IRequest<Guid>
    {
        public string? Title { get; set; }
        public string? Desc { get; set; }
        public string? Icon { get; set; }
        public bool? Status { get; set; }
    }
}
