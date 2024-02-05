using PostAppApi.Application.Interfaces.Commons;
using PostAppApi.Comunicacao.ModelViews.Rating;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Interfaces.Manager
{
    public interface IRatingManager : IManager<Rating>
    {
        Task<Rating> GetRatingOfPost(int postId, int userId);
        Task<IEnumerable<Rating>> GetRatingsNumeric(int postId, int rateStatus);
        public Task<Rating> InsertAsync(PostRatingRequestBody entity);
    }
}
