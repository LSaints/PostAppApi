using PostAppApi.Application.Interfaces.Commons;
using PostAppApi.Comunicacao.ModelViews.Post;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Interfaces.Manager
{
    public interface IPostManager
    {
        public Task<PostGetRequestBody> GetByIdAsync(int id);
        public Task<IEnumerable<PostGetRequestBody>> GetAllAsync();
        public Task DeleteAsync(int id);
        public Task<PostGetRequestBody> InsertAsync(PostPostRequestBody entity);
        public Task<PostGetRequestBody> UpdateAsync(PostPutRequestBody entity);
        public Task<IEnumerable<PostGetRequestBody>> GetAllPostsByUserIdAsync(int id);
        public Task<bool> UserExists(Post entity);
    }
}
