using PostAppApi.Application.Interfaces.Commons;
using PostAppApi.Application.ModelViews.Post;
using PostAppApi.Application.ModelViews.User;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Interfaces.Manager
{
    public interface IPostManager : IManager<Post>
    {
        public Task<Post> InsertAsync(PostPostRequestBody entity);
        public Task<Post> UpdateAsync(PostPutRequestBody entity);
    }
}
