using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.Achievements.Commands.CreateAchievementsCommand
{
    public class CreateAchievementsCommand : IRequest<Guid>
    {
        public string? Title { get; set; }
        public int? Number { get; set; }
        public string? Icon { get; set; }
        public bool? Status { get; set; }
    }
}
