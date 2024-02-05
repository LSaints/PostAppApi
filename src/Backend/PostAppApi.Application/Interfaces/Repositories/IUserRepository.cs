using PostAppApi.Application.Interfaces.Commons;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByLogin(User user);
        Task<User> GetByEmail(string email);
        Task<User> GetByUsername(string username);
    }
}
