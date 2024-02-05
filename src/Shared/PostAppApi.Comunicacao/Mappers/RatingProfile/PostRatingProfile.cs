using AutoMapper;
using PostAppApi.Comunicacao.ModelViews.Rating;
using PostAppApi.Domain.Models;

namespace PostAppApi.Comunicacao.Mappers.RatingProfile
{
    public class PostRatingProfile : Profile
    {
        public PostRatingProfile()
        {
            CreateMap<PostRatingRequestBody, Rating>();
        }
    }
}
