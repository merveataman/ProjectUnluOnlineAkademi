using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsList;
using UnluOnlineAkademi.Domain.Entities;

namespace UnluOnlineAkademi.Application.StudentTestimonial.Queries.StudentTestimonialList
{
    public class GetStudentTestimonialListQuery : IRequest<List<StudentTestimonialDto>>
    {
    }
}
