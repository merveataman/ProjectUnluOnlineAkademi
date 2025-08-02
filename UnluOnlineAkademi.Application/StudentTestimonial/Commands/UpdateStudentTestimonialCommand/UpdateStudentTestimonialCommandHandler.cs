using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.WhyUs.Commands.UpdateWhyUsCommand;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.StudentTestimonial.Commands.UpdateStudentTestimonialCommand
{
    public class UpdateStudentTestimonialCommandHandler : IRequestHandler<UpdateStudentTestimonialCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.StudentTestimonial> _repository;
        private readonly IMapper _mapper;
        public async Task<bool> Handle(UpdateStudentTestimonialCommand request, CancellationToken cancellationToken)
        {
            var existingEntity = await _repository.GetByIdAsync(request.ID);
            if (existingEntity == null)
            {
                return false;
            }
            var entity = _mapper.Map(request, existingEntity);
            var updatedData = await _repository.UpdateAsync(entity);
            return true;
        }
    }
}