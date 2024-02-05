using PostAppApi.Domain.Commons;

namespace PostAppApi.Domain.Models
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? RatingId { get; set; }
        public ICollection<Rating>? Ratings { get; } = new List<Rating>();
    }
}
