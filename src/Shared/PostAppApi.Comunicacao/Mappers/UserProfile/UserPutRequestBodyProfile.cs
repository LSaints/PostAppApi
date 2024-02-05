using AutoMapper;
using PostAppApi.Comunicacao.ModelViews.User;
using PostAppApi.Domain.Models;

namespace PostAppApi.Comunicacao.Mappers.UserProfile
{
    public class UserPutRequestBodyProfile : Profile
    {
        public UserPutRequestBodyProfile()
        {
            CreateMap<UserPutRequestBody, User>();
        }
    }
}
