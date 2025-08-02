using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.Policies.Commands.CreatePoliciesCommand
{
    public class CreatePoliciesCommand : IRequest<Guid>
    {
        public string? Title { get; set; }
        public string? Desc { get; set; }
        public bool? Status { get; set; }
        public DateTime? Date { get; set; }

    }
}
