using AutoMapper;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Application.ModelViews.Post;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Implementations
{
    public class PostManager : IPostManager
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;
        public PostManager(IPostRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Post> InsertAsync(PostPostRequestBody entity)
        {
            var entityBody = _mapper.Map<Post>(entity);
            return await _repository.InsertAsync(entityBody);
        }

        public Task<Post> InsertAsync(Post entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> UpdateAsync(PostPutRequestBody entity)
        {
            var entityBody = _mapper.Map<Post>(entity);
            return await _repository.UpdateAsync(entityBody);
        }

        public Task<Post> UpdateAsync(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
