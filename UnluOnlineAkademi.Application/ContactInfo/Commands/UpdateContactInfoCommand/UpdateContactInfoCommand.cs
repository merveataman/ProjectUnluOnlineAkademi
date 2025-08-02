using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.ContactInfo.Commands.UpdateContactInfoCommand
{
    public class UpdateContactInfoCommand: IRequest<bool>
    {
        public Guid ID { get; set; }
        public string ContactInfo { get; set; }
        public bool? Status { get; set; }
    }
}
