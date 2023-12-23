using AutoMapper;
using PostAppApi.Application.ModelViews.User;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Mappers.UserProfile
{
    public class UserPostRequestBodyProfile : Profile
    {
        public UserPostRequestBodyProfile() 
        {
            CreateMap<UserPostRequestBody, User>();
        }
    }
}
