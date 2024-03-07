using PostAppApi.Domain.Commons;
using PostAppApi.Domain.Models;

namespace PostAppApi.Comunicacao.ModelViews.Group
{
    public class GroupGetRequestBody : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsFree { get; set; }
        public Domain.Models.User Owner { get; set; }
        public ICollection<Domain.Models.Post> Posts { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
    }
}
