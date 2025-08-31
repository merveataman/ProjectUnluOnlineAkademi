using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Domain.Entities
{
    public class Header:BaseEntity
    {
        public string Slogan { get; set; }
        public string Desc { get; set; }
        public string? CoverImage { get; set; }
        public bool? Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
