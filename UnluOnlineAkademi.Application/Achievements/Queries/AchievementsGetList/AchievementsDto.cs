using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.Achievements.Queries.AchievementsGetList
{
    public class AchievementsDto
    {
        public Guid ID { get; set; }
        public string? Title { get; set; }
        public int? Number { get; set; }
        public string? Icon { get; set; }
        public bool? Status { get; set; }
    }
}
