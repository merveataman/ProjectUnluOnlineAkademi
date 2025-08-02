using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.SSS.Queries.SSSList
{
    public class GetSSSListQuery : IRequest<List<SSSDto>>
    {
    }
}
