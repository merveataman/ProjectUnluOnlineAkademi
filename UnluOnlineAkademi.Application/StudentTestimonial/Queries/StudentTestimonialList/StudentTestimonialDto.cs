using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.StudentTestimonial.Queries.StudentTestimonialList
{
    public class StudentTestimonialDto
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Image { get; set; }
        public string? Education { get; set; }
        public string? Testimonial { get; set; }
        public int? Rate { get; set; }
        public bool? Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
