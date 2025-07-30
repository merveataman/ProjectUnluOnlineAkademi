using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Domain.Entities
{
    public class HomeSection:BaseEntity
    {
        public string? KeyName { get; set; }
        public string? Title { get; set; }
        public string? Order { get; set; }
        public bool Status { get; set; }
    }
}
