using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Interfaces.Repositories
{
    public interface IGroupRepository
    {
        public Task<IEnumerable<Group>> GetAllAsync();
        public Task<Group> GetAsync(int id);
        public Task<Group> InsertAsync(Group entity);
        public Task<Group> UpdateAsync(Group entity);
        public Task<Group> DeleteAsync(int id);
        public Task<UserGroup> AddUserToGroup(int userId, int groupId);
    }
}
