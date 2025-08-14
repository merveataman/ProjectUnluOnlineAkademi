using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsById;

namespace UnluOnlineAkademi.Application.SSS.Queries.SSSById
{
    public class SSSByIdQuery : IRequest<SSSByIdDto>
    {
        public Guid ID { get; set; }
    }
}
