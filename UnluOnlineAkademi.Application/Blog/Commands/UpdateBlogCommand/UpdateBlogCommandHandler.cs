using AutoMapper;
using MediatR;
using UnluOnlineAkademi.Domain.Interfaces;

namespace UnluOnlineAkademi.Application.Blog.Commands.UpdateBlogCommand
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, bool>
    {
        private readonly IGenericRepository<Domain.Entities.Blog> _repository;
        private readonly IMapper _mapper;

        public UpdateBlogCommandHandler(IGenericRepository<Domain.Entities.Blog> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
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
