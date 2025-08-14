using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.WhyUs.Commands.CreateWhyUsCommand
{
    public class CreateWhyUsCommand : IRequest<Guid>
    {
        public string? Title { get; set; }
        public string? Desc { get; set; }
        public string? Icon { get; set; }
        public bool? Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
