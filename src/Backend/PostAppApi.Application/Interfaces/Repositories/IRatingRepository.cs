using PostAppApi.Application.Interfaces.Commons;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Interfaces.Repositories
{
    public interface IRatingRepository : IRepository<Rating>
    {
        Task<Rating> GetRatingOfPost(int postId, int userId);
        Task<IEnumerable<Rating>> GetRatingsNumeric(int postId, int rateStatus);
    }
}
