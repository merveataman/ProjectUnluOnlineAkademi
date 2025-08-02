using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.Achievements.Commands.UpdateAchievementsCommand
{
    public class UpdateAchievementsCommand : IRequest<bool>
    {
        public Guid ID { get; set; }
        public string? Title { get; set; }
        public int? Number { get; set; }
        public string? Icon { get; set; }
        public bool? Status { get; set; }
    }
}
