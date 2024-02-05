using AutoMapper;
using PostAppApi.Comunicacao.ModelViews.Post;
using PostAppApi.Domain.Models;

namespace PostAppApi.Comunicacao.Mappers.PostProfile
{
    public class PostPostRequestBodyProfile : Profile
    {
        public PostPostRequestBodyProfile()
        {
            CreateMap<PostPostRequestBody, Post>();
        }
    }
}
