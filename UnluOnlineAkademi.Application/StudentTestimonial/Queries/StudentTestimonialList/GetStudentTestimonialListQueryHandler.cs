using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.StudentTestimonial.Queries.StudentTestimonialList
{
    public class GetStudentTestimonialListQueryHandler : IRequestHandler<GetStudentTestimonialListQuery, List<StudentTestimonialDto>>
    {
        private readonly IGenericRepository<Domain.Entities.StudentTestimonial> _repository;
        private readonly IMapper _mapper;

        public GetStudentTestimonialListQueryHandler(IGenericRepository<Domain.Entities.StudentTestimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<StudentTestimonialDto>> Handle(GetStudentTestimonialListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<StudentTestimonialDto>>(entities);
        }
    }
}
