using PostAppApi.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostAppApi.Domain.Models
{
    public class Rating
    {
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public User User { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }
        public Post Post { get; set; }
        public ERating RateStatus { get; set; }
        public DateTime RateDate { get; set; }
    }
}
