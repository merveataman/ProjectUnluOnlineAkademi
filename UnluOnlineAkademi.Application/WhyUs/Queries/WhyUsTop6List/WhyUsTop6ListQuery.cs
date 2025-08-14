using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsList;

namespace UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsTop6List
{
    public class WhyUsTop6ListQuery : IRequest<List<WhyUsDto>>
    {
    }
}
