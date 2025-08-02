using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.AboutUs.Commands.UpdateAboutUsCommand
{
    public class UpdateAboutUsCommand : IRequest<UpdateAboutUsDto>
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string? Image { get; set; }
        public bool? Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
