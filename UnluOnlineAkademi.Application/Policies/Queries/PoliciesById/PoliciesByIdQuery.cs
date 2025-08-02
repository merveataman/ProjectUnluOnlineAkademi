using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.SSS.Queries.SSSById;

namespace UnluOnlineAkademi.Application.Policies.Queries.PoliciesById
{
    public class PoliciesByIdQuery : IRequest<PoliciesByIdDto>
    {
        public Guid ID { get; set; }
    }
}
