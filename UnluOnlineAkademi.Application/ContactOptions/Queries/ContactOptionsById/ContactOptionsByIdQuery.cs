using MediatR;

namespace UnluOnlineAkademi.Application.ContactOptions.Queries.ContactOptionsById
{
    public class ContactOptionsByIdQuery : IRequest<ContactOptionsByIdDto>
    {
        public Guid ID { get; set; }
    }
}
