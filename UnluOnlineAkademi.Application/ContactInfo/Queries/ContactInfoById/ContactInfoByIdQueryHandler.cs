using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.Blog.Queries.BlogById;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.ContactInfo.Queries.ContactInfoById
{
    public class ContactInfoByIdQueryHandler : IRequestHandler<ContactInfoByIdQuery, ContactInfoByIdDto>
    {
        private readonly IGenericRepository<Domain.Entities.ContactInfos> _repository;
        private readonly IMapper _mapper;

        public ContactInfoByIdQueryHandler(IGenericRepository<Domain.Entities.ContactInfos> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ContactInfoByIdDto> Handle(ContactInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdAsync(request.ID);
            return _mapper.Map<ContactInfoByIdDto>(entities);
        }
    }

}
