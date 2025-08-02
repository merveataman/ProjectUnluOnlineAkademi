using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.Blog.Commands.DeleteBlogCommand
{
    public class DeleteBlogCommand : IRequest<bool>
    {
        public Guid ID { get; set; }
        public DeleteBlogCommand(Guid id)
        {
            ID = id;
        }
    }
}
