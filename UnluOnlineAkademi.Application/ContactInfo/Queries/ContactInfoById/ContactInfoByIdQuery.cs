using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.ContactInfo.Queries.ContactInfoById
{
    public class ContactInfoByIdQuery:IRequest<ContactInfoByIdDto>
    {
        public Guid ID { get; set; }

    }
}
