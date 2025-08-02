using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.MailList.Commands.DeleteMailListCommand
{
    public class DeleteMailListCommand : IRequest<bool>
    {
        public Guid ID { get; set; }

        public DeleteMailListCommand(Guid id)
        {
            ID = id;
        }
    }
}
