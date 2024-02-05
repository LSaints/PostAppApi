using AutoMapper;
using PostAppApi.Application.Interfaces.Manager;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Comunicacao.ModelViews.Rating;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Implementations
{
    public class RatingManager : IRatingManager
    {
        private readonly IRatingRepository _repository;
        private readonly IMapper _mapper;

        public RatingManager(IRatingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Rating>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Rating> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Rating> GetRatingOfPost(int postId, int userId)
        {
            return await _repository.GetRatingOfPost(postId, userId);
        }

        public async Task<IEnumerable<Rating>> GetRatingsNumeric(int postId, int rateStatus)
        {
            return await _repository.GetRatingsNumeric(postId, rateStatus);
        }

        public async Task<Rating> InsertAsync(PostRatingRequestBody entity)
        {
            var entityBody = _mapper.Map<Rating>(entity);
            return await _repository.InsertAsync(entityBody);
        }

        public Task<Rating> InsertAsync(Rating entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Rating> UpdateAsync(Rating entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
