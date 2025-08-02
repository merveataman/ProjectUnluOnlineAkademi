using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.MailList.Queries.MailListById
{
    public class MailListByIdQuery : IRequest<MailListByIdDto>
    {
        public Guid ID { get; set; }

    }
}
