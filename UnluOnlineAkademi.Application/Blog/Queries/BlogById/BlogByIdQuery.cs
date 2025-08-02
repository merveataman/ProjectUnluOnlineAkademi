using MediatR;

namespace UnluOnlineAkademi.Application.Blog.Queries.BlogById
{
    public class BlogByIdQuery : IRequest<BlogByIdDto>
    {
        public Guid ID { get; set; }

    }
}
