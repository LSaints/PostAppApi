using PostAppApi.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostAppApi.Comunicacao.ModelViews.Rating
{
    public class PostRatingRequestBody
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }
        public ERating RateStatus { get; set; }
    }
}
