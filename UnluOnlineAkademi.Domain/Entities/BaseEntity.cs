using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
