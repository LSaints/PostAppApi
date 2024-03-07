using PostAppApi.Comunicacao.ModelViews.Post;
using PostAppApi.Comunicacao.ModelViews.User;
using PostAppApi.Domain.Commons;
using PostAppApi.Domain.Models;

namespace PostAppApi.Comunicacao.ModelViews.Group
{
    public class GroupGetRequestBody : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsFree { get; set; }
        public UserGetRequestBody Owner { get; set; }
        public ICollection<PostGetRequestBody> Posts { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
    }
}
