using Microsoft.EntityFrameworkCore;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Domain.Enums;
using PostAppApi.Domain.Models;

namespace PostAppApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PostAppApiContext _context;
        public UserRepository(PostAppApiContext context) 
        { 
            _context = context; 
        }

        public async Task<User> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            var userForRemove = _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return userForRemove.Entity;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(e => e.Posts)
                .AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users
                .FromSqlRaw($"select * from users where Email = '{email}'").FirstOrDefaultAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(e => e.Posts)
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<User> GetByLogin(User user)
        {
            string sql = $"select * from users where Email = '{user.Email}' and Password = '{user.Password}'";
            return await _context.Users.FromSqlRaw(sql).FirstOrDefaultAsync();
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _context.Users
                .FromSqlRaw($"select * from users where Username = '{username}'").FirstOrDefaultAsync();
        }

        public async Task<User> InsertAsync(User entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.Roles = Roles.User;
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<User> UpdateAsync(User entity)
        {
            var entityFind = await _context.Users.FindAsync(entity.Id);
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
