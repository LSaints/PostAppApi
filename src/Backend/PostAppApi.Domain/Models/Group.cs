using PostAppApi.Domain.Commons;

namespace PostAppApi.Domain.Models
{
    public class Group : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<UserGroup>? UserGroups { get; set; }
    }
}
