using PostAppApi.Application.Interfaces.Commons;
using PostAppApi.Application.ModelViews.User;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Interfaces.Manager
{
    public interface IUserManager : IManager<User>
    {
        public Task<User> InsertAsync(UserPostRequestBody entity);
        public Task<User> UpdateAsync(UserPutRequestBody entity);
    }
}
