using AutoMapper;
using PostAppApi.Application.ModelViews.User;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Mappers.UserProfile
{
    public class UserPutRequestBodyProfile : Profile
    {
        public UserPutRequestBodyProfile() 
        {
            CreateMap<UserPutRequestBody, User>();
        }
    }
}
