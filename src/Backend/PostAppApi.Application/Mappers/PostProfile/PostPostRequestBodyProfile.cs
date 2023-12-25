using AutoMapper;
using PostAppApi.Application.ModelViews.Post;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Mappers.PostProfile
{
    public class PostPostRequestBodyProfile : Profile
    {
        public PostPostRequestBodyProfile() 
        {
            CreateMap<PostPostRequestBody, Post>();
        }
    }
}
