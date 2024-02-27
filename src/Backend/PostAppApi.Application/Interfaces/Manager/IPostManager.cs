using PostAppApi.Application.Interfaces.Commons;
using PostAppApi.Comunicacao.ModelViews.Post;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Interfaces.Manager
{
    public interface IPostManager : IManager<Post>
    {
        public Task<Post> InsertAsync(PostPostRequestBody entity);
        public Task<Post> UpdateAsync(PostPutRequestBody entity);
        public Task<IEnumerable<Post>> GetAllPostsByUserIdAsync(int id);
        public Task<bool> UserExists(Post entity);
    }
}
