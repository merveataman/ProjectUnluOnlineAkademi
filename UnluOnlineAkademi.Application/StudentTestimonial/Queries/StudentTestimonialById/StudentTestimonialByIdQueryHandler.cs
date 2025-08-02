using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsById;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.StudentTestimonial.Queries.StudentTestimonialById
{
    public class StudentTestimonialByIdQueryHandler : IRequestHandler<StudentTestimonialByIdQuery, StudentTestimonialByIdDto>
    {
        private readonly IGenericRepository<Domain.Entities.StudentTestimonial> _repository;
        private readonly IMapper _mapper;

        public StudentTestimonialByIdQueryHandler(IGenericRepository<Domain.Entities.StudentTestimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StudentTestimonialByIdDto> Handle(StudentTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdAsync(request.ID);
            return _mapper.Map<StudentTestimonialByIdDto>(entities);
        }
    }
}
