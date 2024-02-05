using Microsoft.EntityFrameworkCore;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Domain.Models;

namespace PostAppApi.Infrastructure.Repositories
{
    public class RatingRepository : IRatingRepository
    {

        private readonly PostAppApiContext _context;

        public RatingRepository(PostAppApiContext context)
        {
            _context = context;
        }

        public async Task<Rating> DeleteAsync(int id)
        {
            var rating = await _context.Ratings.FindAsync(id);
            if (rating == null)
            {
                return null;
            }
            var ratingForRemove = _context.Ratings.Remove(rating);
            await _context.SaveChangesAsync();
            return ratingForRemove.Entity;
        }

        public async Task<IEnumerable<Rating>> GetAllAsync()
        {
            return await _context.Ratings
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Rating> GetRatingOfPost(int postId, int userId)
        {
            return await _context.Ratings
                .FromSqlRaw($"select * from db_postapp.ratings where PostId = {postId} and UserId = {userId}")
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Rating>> GetRatingsNumeric(int postId, int rateStatus)
        {
            return await _context.Ratings
                .FromSqlRaw($"select * from ratings where PostId = {postId} and RateStatus = {rateStatus}")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Rating> GetByIdAsync(int id)
        {
            return await _context.Ratings
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Rating> InsertAsync(Rating entity)
        {
            entity.RateDate = DateTime.Now;
            await _context.Ratings.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Rating> UpdateAsync(Rating entity)
        {
            var entityFind = await _context.Ratings.FindAsync(entity.Id);
            entity.RateDate = entityFind.RateDate;
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
