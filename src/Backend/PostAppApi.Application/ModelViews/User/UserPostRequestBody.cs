namespace PostAppApi.Application.ModelViews.User
{
    public class UserPostRequestBody
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Domain.Models.Post> Posts { get; } = new List<Domain.Models.Post>();
    }
}
