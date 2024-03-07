using PostAppApi.Comunicacao.ModelViews.Group;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Interfaces.Manager
{
    public interface IGroupManager
    {
        Task<GroupGetRequestBody> GetByIdAsync(int id);
        Task<IEnumerable<GroupGetRequestBody>> GetAllAsync();
        Task<GroupGetRequestBody> InsertAsync(GroupPostRequestBody entity);
        Task<GroupGetRequestBody> UpdateAsync(GroupPutRequestBody entity);
        Task DeleteAsync(int id);
        Task<UserGroup> AddUserToGroup(int userId, int groupId);
    }
}
