using PostAppApi.Application.Interfaces.Commons;
using PostAppApi.Comunicacao.ModelViews.User;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Interfaces.Manager
{
    public interface IUserManager
    {
        Task<IEnumerable<UserGetRequestBody>> GetAllAsync();
        public Task<UserGetRequestBody> InsertAsync(UserPostRequestBody entity);
        public Task<UserGetRequestBody> UpdateAsync(UserPutRequestBody entity);
        public Task<UserGetRequestBody> GetByLogin(UserLoginRequestBody user);
        public Task<UserGetRequestBody> GetByEmailAsync(string email);
        public Task<UserGetRequestBody> GetByUsername(string username);
        public Task<UserGetRequestBody> GetByIdAsync(int id);
        public Task DeleteAsync(int id);
    }
}
