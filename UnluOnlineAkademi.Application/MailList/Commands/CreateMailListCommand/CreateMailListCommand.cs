using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.MailList.Commands.CreateMailListCommand
{
    public class CreateMailListCommand:IRequest<Guid>
    {
        public string? Topic { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Message { get; set; }
        public string? EmailAddress { get; set; }
        public string? Answer { get; set; }
        public bool? Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
