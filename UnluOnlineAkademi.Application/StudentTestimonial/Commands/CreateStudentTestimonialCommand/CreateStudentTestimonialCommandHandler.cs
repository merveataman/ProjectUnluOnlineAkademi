using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.StudentTestimonial.Commands.CreateStudentTestimonialCommand
{
    public class CreateStudentTestimonialCommandHandler : IRequestHandler<CreateStudentTestimonialCommand, Guid>
    {
        private readonly IGenericRepository<Domain.Entities.StudentTestimonial> _repository;
        private readonly IMapper _mapper;

        public CreateStudentTestimonialCommandHandler(IGenericRepository<Domain.Entities.StudentTestimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateStudentTestimonialCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UnluOnlineAkademi.Domain.Entities.StudentTestimonial>(request);
            var createdData = await _repository.AddAsync(entity);
            return createdData.ID;
        }
    }
}
