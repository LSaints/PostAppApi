using AutoMapper;
using PostAppApi.Comunicacao.ModelViews.User;
using PostAppApi.Domain.Models;

namespace PostAppApi.Comunicacao.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserLoginRequestBody, User>();
            CreateMap<UserPostRequestBody, User>();
            CreateMap<UserPutRequestBody, User>();
            CreateMap<User, UserGetRequestBody>();
        }
    }
}
