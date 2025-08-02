using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Blog.Queries.BlogById
{
    public class BlogByIdQueryHandler : IRequestHandler<BlogByIdQuery, BlogByIdDto>
    {
        private readonly IGenericRepository<Domain.Entities.Blog> _repository;
        private readonly IMapper _mapper;

        public BlogByIdQueryHandler(IGenericRepository<Domain.Entities.Blog> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BlogByIdDto> Handle(BlogByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByIdAsync(request.ID);
            return _mapper.Map<BlogByIdDto>(entities);
        }
    }
}
