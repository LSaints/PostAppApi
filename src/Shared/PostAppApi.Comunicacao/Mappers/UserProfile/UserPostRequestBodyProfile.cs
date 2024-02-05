using AutoMapper;
using PostAppApi.Comunicacao.ModelViews.User;
using PostAppApi.Domain.Models;

namespace PostAppApi.Comunicacao.Mappers.UserProfile
{
    public class UserPostRequestBodyProfile : Profile
    {
        public UserPostRequestBodyProfile()
        {
            CreateMap<UserPostRequestBody, User>();
        }
    }
}
