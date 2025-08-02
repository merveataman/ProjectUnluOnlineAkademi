using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluOnlineAkademi.Application.StudentTestimonial.Commands.DeleteStudentTestimonialCommand
{
    public class DeleteStudentTestimonialCommand : IRequest<bool>
    {
        public Guid ID { get; set; }
        public DeleteStudentTestimonialCommand(Guid id)
        {
            ID = id;
        }
    }
}
