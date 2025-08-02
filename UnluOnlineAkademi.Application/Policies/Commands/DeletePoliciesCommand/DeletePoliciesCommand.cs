using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.Policies.Commands.DeletePoliciesCommand
{
    public class DeletePoliciesCommand : IRequest<bool>
    {
        public Guid ID { get; set; }

        public DeletePoliciesCommand(Guid id)
        {
            ID = id;
        }
    }
}
