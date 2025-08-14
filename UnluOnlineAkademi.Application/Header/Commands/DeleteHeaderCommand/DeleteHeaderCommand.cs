using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.Header.Commands.DeleteHeaderCommand
{
    public class DeleteHeaderCommand : IRequest<bool>
    {
        public Guid ID { get; set; }
        public DeleteHeaderCommand(Guid id)
        {
            ID = id;
        }

    }
}
