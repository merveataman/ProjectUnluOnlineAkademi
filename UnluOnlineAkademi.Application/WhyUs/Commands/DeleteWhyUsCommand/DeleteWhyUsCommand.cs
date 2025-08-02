using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.WhyUs.Commands.DeleteWhyUsCommand
{
    public class DeleteWhyUsCommand : IRequest<bool>
    {
        public Guid ID { get; set; }
        public DeleteWhyUsCommand(Guid id)
        {
            ID = id;
        }
    }
}
