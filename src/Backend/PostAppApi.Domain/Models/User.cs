using PostAppApi.Domain.Commons;
using PostAppApi.Domain.Enums;

namespace PostAppApi.Domain.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Roles { get; set; }
        public ICollection<Post>? Posts { get; } = new List<Post>();
        public ICollection<UserGroup>? UserGroups { get; set; }

    }
}
