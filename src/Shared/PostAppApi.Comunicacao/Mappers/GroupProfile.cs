using AutoMapper;
using PostAppApi.Comunicacao.ModelViews.Group;
using PostAppApi.Domain.Models;

namespace PostAppApi.Comunicacao.Mappers
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<GroupPostRequestBody, Group >();
            CreateMap<GroupPutRequestBody, Group>();
            CreateMap<Group, GroupGetRequestBody>();
        }
    }
}
