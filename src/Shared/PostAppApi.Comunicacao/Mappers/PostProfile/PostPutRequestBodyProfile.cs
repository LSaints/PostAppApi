using AutoMapper;
using PostAppApi.Comunicacao.ModelViews.Post;
using PostAppApi.Domain.Models;

namespace PostAppApi.Comunicacao.Mappers.PostProfile
{
    public class PostPutRequestBodyProfile : Profile
    {
        public PostPutRequestBodyProfile()
        {
            CreateMap<PostPutRequestBody, Post>();
        }
    }
}
