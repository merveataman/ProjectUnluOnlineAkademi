using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Blog.Commands.DeleteBlogCommand
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.Blog> _repository;
        private readonly IMapper _mapper;

        public DeleteBlogCommandHandler(IGenericRepository<Domain.Entities.Blog> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.ID);
            if (entity == null) { return false; }
            await _repository.DeleteAsync(entity.ID);
            return true;
        }
    }
}
