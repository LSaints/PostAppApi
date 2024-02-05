using System.ComponentModel.DataAnnotations;

namespace PostAppApi.Comunicacao.ModelViews.Post
{
    public class PostPostRequestBody
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
