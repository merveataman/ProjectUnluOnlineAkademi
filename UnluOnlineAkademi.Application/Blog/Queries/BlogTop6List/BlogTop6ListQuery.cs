using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.Blog.Queries.BlogGetList;

namespace UnluOnlineAkademi.Application.Blog.Queries.WhyUsTop6List
{
    public class BlogTop6ListQuery : IRequest<List<BlogDto>>
    {
    }
}
