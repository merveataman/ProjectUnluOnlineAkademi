using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.EducationalContent.Queries.EducationalContentById
{
    public class EducationalContentByIdQuery : IRequest<EducationalContentByIdDto>
    {
        public Guid ID { get; set; }
    }
}
