using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.MailList.Queries.MailListList
{
    public class GetMailListListQuery : IRequest<List<MailListDto>>
    {
    }
}
