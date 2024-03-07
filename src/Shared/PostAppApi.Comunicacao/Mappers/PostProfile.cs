using AutoMapper;
using PostAppApi.Comunicacao.ModelViews.Post;
using PostAppApi.Domain.Models;

namespace PostAppApi.Comunicacao.Mappers
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostPostRequestBody, Post>();
            CreateMap<PostPutRequestBody, Post>();
            CreateMap<Post, PostGetRequestBody>();
        }
    }
}
