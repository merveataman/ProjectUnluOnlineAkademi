using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.StudentTestimonial.Commands.CreateStudentTestimonialCommand
{
    public class CreateStudentTestimonialCommand : IRequest<Guid>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Image { get; set; }
        public string? Education { get; set; }
        public string? Testimonial { get; set; }
        public int? Rate { get; set; }
        public DateTime? Date { get; set; }
    }
}
