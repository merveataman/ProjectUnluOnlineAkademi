using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.Blog.Commands.UpdateBlogCommand
{
    public class UpdateBlogCommand:IRequest<bool>
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string? Author { get; set; }
        public string? CoverImg { get; set; }
        public string? Image { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool? Status { get; set; }
    }
}
