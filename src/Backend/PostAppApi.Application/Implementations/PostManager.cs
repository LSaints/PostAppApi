using AutoMapper;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Comunicacao.ModelViews.Group;
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

        public async Task<IEnumerable<PostGetRequestBody>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<Post>, IEnumerable<PostGetRequestBody>>(await _repository.GetAllAsync());
        }

        public async Task<IEnumerable<PostGetRequestBody>> GetAllPostsByUserIdAsync(int id)
        {
            var posts = await _repository.GetAllPostsByUserIdAsync(id);
            if (posts.All(p => p.UserId == null)) throw new PostNotFoundException();
            return _mapper.Map<IEnumerable<Post>, IEnumerable<PostGetRequestBody>>(await _repository.GetAllPostsByUserIdAsync(id));
        }

        public async Task<PostGetRequestBody> GetByIdAsync(int id)
        {
            var post = _mapper.Map<Post, PostGetRequestBody>(await _repository.GetByIdAsync(id));;
            if (post == null) throw new PostNotFoundException();
            return post;
        }

        public async Task<PostGetRequestBody> InsertAsync(PostPostRequestBody entity)
        {

            var entityBody = _mapper.Map<Post>(entity);

            if (entity.UserId <= 0) throw new UnattributedPostException();
            if (await UserExists(entityBody) == false) throw new UserPostNotFoundException();

            return _mapper.Map<Post, PostGetRequestBody>(await _repository.InsertAsync(entityBody));
        }

        public async Task<PostGetRequestBody> UpdateAsync(PostPutRequestBody entity)
        {

            var entityBody = _mapper.Map<Post>(entity);
            var post = await _repository.GetByIdAsync(entity.Id);

            if (post == null || entity.Id <= 0) throw new PostNotFoundException();
            if (entity.UserId <= 0) throw new UnattributedPostException();
            if (await UserExists(entityBody) == false) throw new UserPostNotFoundException();

            return _mapper.Map<Post, PostGetRequestBody>(await _repository.UpdateAsync(entityBody));
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
