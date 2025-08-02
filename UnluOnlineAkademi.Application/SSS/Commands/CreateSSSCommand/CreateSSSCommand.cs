using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.SSS.Commands.CreateSSSCommand
{
    public class CreateSSSCommand : IRequest<Guid>
    {
        public string? Quetion { get; set; }
        public string? Answer { get; set; }
        public bool? Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
