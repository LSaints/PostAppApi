using PostAppApi.Application.Interfaces.Commons;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Interfaces.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Post>> GetAllPostsByUserIdAsync(int id);
    }
}
