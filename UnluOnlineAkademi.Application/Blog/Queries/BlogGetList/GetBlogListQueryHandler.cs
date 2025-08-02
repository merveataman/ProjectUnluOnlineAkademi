using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Blog.Queries.BlogGetList
{
    public class GetBlogListQueryHandler : IRequestHandler<GetBlogListQuery, List<BlogDto>>
    {
        private readonly IGenericRepository<Domain.Entities.Blog> _repository;
        private readonly IMapper _mapper;

        public GetBlogListQueryHandler(IGenericRepository<Domain.Entities.Blog> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<BlogDto>> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<BlogDto>>(entities);
        }
    }
}
