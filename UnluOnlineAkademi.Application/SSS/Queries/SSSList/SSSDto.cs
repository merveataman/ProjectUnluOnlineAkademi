using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.SSS.Queries.SSSList
{
    public class SSSDto
    {
        public Guid ID { get; set; }
        public string? Quetion { get; set; }
        public string? Answer { get; set; }
        public bool? Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
