using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Blog.Commands.CreateBlogCommand
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Guid>
    {
        private readonly IGenericRepository<Domain.Entities.Blog> _repository;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IGenericRepository<Domain.Entities.Blog> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UnluOnlineAkademi.Domain.Entities.Blog>(request);
            var createdData = await _repository.AddAsync(entity);
            return createdData.ID;
        }
    }
}
