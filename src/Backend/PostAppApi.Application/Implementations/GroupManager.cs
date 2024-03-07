using AutoMapper;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Comunicacao.ModelViews.Group;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Implementations
{
    public class GroupManager : IGroupManager
    {

        private readonly IGroupRepository _repository;
        private readonly IMapper _mapper;

        public GroupManager(IGroupRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<UserGroup> AddUserToGroup(int userId, int groupId)
        {
            return _repository.AddUserToGroup(userId, groupId);
        }

        public async Task DeleteAsync(int id)
        {
            var group = await _repository.GetAsync(id);
            if (group == null || id <= 0) throw new ArgumentException();
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GroupGetRequestBody>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<Group>, IEnumerable <GroupGetRequestBody>>(await _repository.GetAllAsync());
        }

        public async Task<GroupGetRequestBody> GetByIdAsync(int id)
        {
            var group = _mapper.Map<Group, GroupGetRequestBody>(await _repository.GetAsync(id));
            if (group == null) throw new ArgumentException();
            return group;
        }

        public async Task<GroupGetRequestBody> InsertAsync(GroupPostRequestBody entity)
        {
            var group = _mapper.Map<Group>(entity);
            return _mapper.Map<GroupGetRequestBody>(await _repository.InsertAsync(group));
        }

        public async Task<GroupGetRequestBody> UpdateAsync(GroupPutRequestBody entity)
        {
            var group = _mapper.Map<Group>(entity);
            return _mapper.Map<GroupGetRequestBody>(await _repository.UpdateAsync(group));
        }
    }
}
