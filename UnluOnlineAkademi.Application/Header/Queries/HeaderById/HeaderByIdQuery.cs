using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.Header.Queries.HeaderById
{
    public class HeaderByIdQuery :IRequest<HeaderByIdDto>
    {
        public Guid ID { get; set; }
    }
}
