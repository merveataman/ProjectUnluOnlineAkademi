using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.StudentTestimonial.Queries.StudentTestimonialById
{
    public class StudentTestimonialByIdQuery :IRequest<StudentTestimonialByIdDto>
    {
        public Guid ID { get; set; }
    }
}
