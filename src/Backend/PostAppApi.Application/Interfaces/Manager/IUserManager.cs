using PostAppApi.Application.Interfaces.Commons;
using PostAppApi.Comunicacao.ModelViews.User;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Interfaces.Manager
{
    public interface IUserManager : IManager<User>
    {
        public Task<User> InsertAsync(UserPostRequestBody entity);
        public Task<User> UpdateAsync(UserPutRequestBody entity);
        public Task<User> GetByLogin(UserLoginRequestBody user);
        public Task<User> GetByEmailAsync(string email);
        public Task<User> GetByUsername(string username);
    }
}
