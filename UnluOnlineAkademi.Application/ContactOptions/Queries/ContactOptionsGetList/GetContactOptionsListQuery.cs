using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.ContactOptions.Queries.ContactOptionsGetList
{
    public class GetContactOptionsListQuery:IRequest<List<ContactOptionsDto>>
    {
    }
}
