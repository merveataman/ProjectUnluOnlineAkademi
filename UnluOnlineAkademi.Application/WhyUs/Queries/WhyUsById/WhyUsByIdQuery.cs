using MediatR;

namespace UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsById
{
    public class WhyUsByIdQuery : IRequest<WhyUsByIdDto>
    {
        public Guid ID { get; set; }
    }
}