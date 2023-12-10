using PostAppApi.Domain.Common;

namespace PostAppApi.Domain.Models
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
