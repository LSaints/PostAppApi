using PostAppApi.Domain.Models;

namespace PostAppApi.Application.ModelViews.User
{
    public class UserPostRequestBody
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Post> Posts { get; } = new List<Post>();
    }
}
