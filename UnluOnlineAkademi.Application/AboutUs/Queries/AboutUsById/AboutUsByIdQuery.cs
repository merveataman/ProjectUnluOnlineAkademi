using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.AboutUs.Queries.AboutUsById
{
    public class AboutUsByIdQuery:IRequest<AboutUsByIdDto>
    {
        public Guid ID { get; set; }
    }
}
