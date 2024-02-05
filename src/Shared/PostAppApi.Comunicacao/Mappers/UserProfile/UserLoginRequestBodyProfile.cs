using AutoMapper;
using PostAppApi.Comunicacao.ModelViews.User;
using PostAppApi.Domain.Models;

namespace PostAppApi.Comunicacao.Mappers.UserProfile
{
    public class UserLoginRequestBodyProfile : Profile
    {
        public UserLoginRequestBodyProfile() 
        {
            CreateMap<UserLoginRequestBody, User>();
        }
    }
}
