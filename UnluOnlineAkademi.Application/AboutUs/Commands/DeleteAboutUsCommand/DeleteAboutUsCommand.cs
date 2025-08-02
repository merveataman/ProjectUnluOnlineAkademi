using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.AboutUs.Commands.DeleteAboutUsCommand
{
    public class DeleteAboutUsCommand : IRequest<bool>
    {
        public Guid ID { get; set; }

        public DeleteAboutUsCommand(Guid id)
        {
            ID = id;
        }
    }
}
