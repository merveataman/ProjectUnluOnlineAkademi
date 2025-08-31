using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.Header.Queries.HeaderList
{
    public class HeaderListQuery : IRequest<List<HeaderDto>>
    {
    }
}
