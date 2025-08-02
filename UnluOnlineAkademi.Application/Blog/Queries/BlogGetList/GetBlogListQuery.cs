using MediatR;

namespace UnluOnlineAkademi.Application.Blog.Queries.BlogGetList
{
    public class GetBlogListQuery : IRequest<List<BlogDto>>
    {
    }
}
