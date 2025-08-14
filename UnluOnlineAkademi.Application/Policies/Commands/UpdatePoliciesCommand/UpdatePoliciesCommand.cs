using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.Policies.Commands.UpdatePoliciesCommand
{
    public class UpdatePoliciesCommand : IRequest<bool>
    {
        public Guid ID { get; set; }
        public string? Title { get; set; }
        public string? Desc { get; set; }
        public bool? Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
