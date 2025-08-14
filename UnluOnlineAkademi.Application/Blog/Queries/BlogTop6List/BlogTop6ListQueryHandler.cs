using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluOnlineAkademi.Application.Blog.Queries.BlogGetList;
using UnluOnlineAkademi.Application.Blog.Queries.WhyUsTop6List;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsList;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsTop6List;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Blog.Queries.BlogTop6List
{
    public class BlogTop6ListQueryHandler : IRequestHandler<BlogTop6ListQuery, List<BlogDto>>
    {
        private readonly IGenericRepository<Domain.Entities.WhyUs> _repository;
        private readonly IMapper _mapper;

        public BlogTop6ListQueryHandler(IGenericRepository<Domain.Entities.WhyUs> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BlogDto>> Handle(BlogTop6ListQuery request, CancellationToken cancellationToken)
        {
            var all = await _repository.GetAllAsync();
            var top6 = all
                .OrderByDescending(x => x.CreatedDate)
                .Take(3)
                .ToList();

            return _mapper.Map<List<BlogDto>>(top6);
        }
    }
}
