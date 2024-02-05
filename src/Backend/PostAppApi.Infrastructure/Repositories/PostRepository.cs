using Microsoft.EntityFrameworkCore;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Domain.Models;

namespace PostAppApi.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly PostAppApiContext _context;

        public PostRepository(PostAppApiContext context)
        {
            _context = context;
        }
        public async Task<Post> DeleteAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return null;
            }
            var postForRemove = _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return postForRemove.Entity;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _context.Posts
                .Include(e => e.User)
                .Include(e => e.Ratings)
                .OrderByDescending(e => e.CreatedAt.Date)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetAllPostsByUserIdAsync(int id)
        {
            return await _context.Posts
                .FromSqlRaw($"select * from posts where UserId = {id}").AsNoTracking().ToListAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _context.Posts
                .Include(e => e.User)
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Post> InsertAsync(Post entity)
        {
            entity.CreatedAt = DateTime.Now;
            await _context.Posts.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Post> UpdateAsync(Post entity)
        {
            var entityFind = await _context.Posts.FindAsync(entity.Id);
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
