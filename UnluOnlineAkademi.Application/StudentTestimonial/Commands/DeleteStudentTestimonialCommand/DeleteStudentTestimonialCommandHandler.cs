using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.StudentTestimonial.Commands.DeleteStudentTestimonialCommand
{
    public class DeleteStudentTestimonialCommandHandler : IRequestHandler<DeleteStudentTestimonialCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.StudentTestimonial> _repository;
        private readonly IMapper _mapper;

        public DeleteStudentTestimonialCommandHandler(IGenericRepository<Domain.Entities.StudentTestimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteStudentTestimonialCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.ID);
            if (entity == null) { return false; }
            await _repository.DeleteAsync(entity.ID);
            return true;
        }
    }
}
