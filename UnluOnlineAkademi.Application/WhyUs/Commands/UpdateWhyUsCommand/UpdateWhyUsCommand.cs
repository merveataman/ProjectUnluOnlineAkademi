using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.WhyUs.Commands.UpdateWhyUsCommand
{
    public class UpdateWhyUsCommand : IRequest<bool>
    {
        public Guid ID { get; set; }
        public string? Title { get; set; }
        public string? Desc { get; set; }
        public string? Icon { get; set; }
        public bool? Status { get; set; }
        public DateTime? Date { get; set; }
    }
}