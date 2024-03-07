using Microsoft.EntityFrameworkCore;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Domain.Models;


namespace PostAppApi.Infrastructure.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly PostAppApiContext _context;

        public GroupRepository(PostAppApiContext context)
        {
            _context = context;
        }

        public async Task<UserGroup> AddUserToGroup(int userId, int groupId)
        {
            var user = _context.Users.Find(userId);
            var group = _context.Groups.Find(groupId);

            if (user == null && group == null)
                return null;
            
            var userGroup = new UserGroup { UserId = userId, GroupId = groupId };
            _context.UserGroups.Add(userGroup);
            await _context.SaveChangesAsync();
            return userGroup;

        }

        public async Task<Group> DeleteAsync(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group == null)
            {
                return null;
            }
            var groupForRemove = _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
            return groupForRemove.Entity;
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _context.Groups
                .Include(e => e.UserGroups)
                .ThenInclude(e => e.User)
                .Include(e => e.Owner)
                .ThenInclude(e => e.Posts)
                .Include(e => e.UserGroups)
                .OrderByDescending(e => e.CreatedAt.Date)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Group> GetAsync(int id)
        {
            return await _context.Groups
                .Include(e => e.UserGroups)
                .ThenInclude(e => e.User)
                .Include(e => e.Owner)
                .ThenInclude(e => e.Posts)
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Group> InsertAsync(Group entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.Owner = await _context.Users.FindAsync(entity.OwnerId);
            await _context.Groups.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Group> UpdateAsync(Group entity)
        {
            var entityFind = await _context.Groups.FindAsync(entity.Id);
            entity.CreatedAt = entityFind.CreatedAt;
            entity.UpdatedAt = DateTime.Now;
            if (entityFind == null)
            {
                return null;
            }
            _context.Entry(entityFind).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
