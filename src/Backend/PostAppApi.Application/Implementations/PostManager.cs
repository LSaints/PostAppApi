using AutoMapper;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Comunicacao.ModelViews.Post;
using PostAppApi.Domain.Models;
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
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<Post>> GetAllPostsByUserIdAsync(int id)
        {
            return await _repository.GetAllPostsByUserIdAsync(id);
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            var post = await _repository.GetByIdAsync(id);
            if (post == null)
                throw new Exception("ID da postagem informado não foi encontrado ou é inválido");

            return post;
        }

        public async Task<Post> InsertAsync(PostPostRequestBody entity)
        {
            if (entity.UserId <= 0)
                throw new Exception("Postagem não foi atribuida a nenhum usuário");

            Validator.ValidateObject(entity, new ValidationContext(entity), true);
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
