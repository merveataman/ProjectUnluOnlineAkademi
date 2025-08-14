using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.Achievements.Commands.DeleteAchievementsCommand
{
    public class DeleteAchievementsCommand : IRequest<bool>
    {
        public Guid ID { get; set; }

        public DeleteAchievementsCommand(Guid id)
        {
            ID = id;
        }
    }
}
