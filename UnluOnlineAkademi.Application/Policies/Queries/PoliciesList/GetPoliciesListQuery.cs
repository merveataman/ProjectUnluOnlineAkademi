using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.SSS.Queries.SSSList;

namespace UnluOnlineAkademi.Application.Policies.Queries.PoliciesList
{
    public class GetPoliciesListQuery : IRequest<List<PoliciesDto>>
    {
    }
}
