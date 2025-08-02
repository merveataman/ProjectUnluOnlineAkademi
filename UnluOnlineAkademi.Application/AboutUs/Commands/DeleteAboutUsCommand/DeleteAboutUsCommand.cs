using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.AboutUs.Commands.DeleteAboutUsCommand
{
    public class DeleteAboutUsCommand:IRequest<DeleteAboutUsDto>
    {
        public Guid ID { get; set; }
    }
}
