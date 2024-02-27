using AutoMapper;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Comunicacao.ModelViews.Post;
using PostAppApi.Domain.Models;
using PostAppApi.Exceptions.PostExceptions;
using System.ComponentModel.DataAnnotations;

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
            var post = await _repository.GetByIdAsync(id);
            if (post == null || id <= 0) throw new PostNotFoundException();
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<Post>> GetAllPostsByUserIdAsync(int id)
        {
            var posts = await _repository.GetAllPostsByUserIdAsync(id);
            if (posts.All(p => p.UserId == null)) throw new PostNotFoundException();
            return posts;
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            var post = await _repository.GetByIdAsync(id);
            if (post == null) throw new PostNotFoundException();
            return post;
        }

        public async Task<Post> InsertAsync(PostPostRequestBody entity)
        {

            Validator.ValidateObject(entity, new ValidationContext(entity), true);
            var entityBody = _mapper.Map<Post>(entity);

            if (entity.UserId <= 0) throw new UnattributedPostException();
            if (await UserExists(entityBody) == false) throw new UserPostNotFoundException();

            return await _repository.InsertAsync(entityBody);
        }

        public Task<Post> InsertAsync(Post entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> UpdateAsync(PostPutRequestBody entity)
        {

            var entityBody = _mapper.Map<Post>(entity);
            var post = await _repository.GetByIdAsync(entity.Id);

            if (post == null || entity.Id <= 0) throw new PostNotFoundException();
            if (entity.UserId <= 0) throw new UnattributedPostException();
            if (await UserExists(entityBody) == false) throw new UserPostNotFoundException();

            return await _repository.UpdateAsync(entityBody);
        }

        public Task<Post> UpdateAsync(Post entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserExists(Post entity)
        {
            var result = await _repository.UserExists(entity);
            if (result == false)
                return result;
            return result;
        }
    }
}
