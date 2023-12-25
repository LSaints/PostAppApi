using AutoMapper;
using PostAppApi.Application.ModelViews.Post;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Mappers.PostProfile
{
    public class PostPutRequestBodyProfile : Profile
    {
        public PostPutRequestBodyProfile() 
        {
            CreateMap<PostPutRequestBody, Post>();
        }
    }
}
