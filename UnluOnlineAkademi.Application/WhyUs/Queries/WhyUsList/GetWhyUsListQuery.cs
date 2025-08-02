using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsList
{
    public class GetWhyUsListQuery : IRequest<List<WhyUsDto>>
    {
    }
}
