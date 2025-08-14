using MediatR;

namespace UnluOnlineAkademi.Application.EducationalContent.Commands.UpdateEducationalContentCommand
{
    public class UpdateEducationalContentCommand : IRequest<bool>
    {
        public Guid ID { get; set; }
        public string? Title { get; set; }
        public string? Desc { get; set; }
        public string? Icon { get; set; }
        public bool? Status { get; set; }
    }
}
