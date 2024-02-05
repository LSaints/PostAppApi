using PostAppApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PostAppApi.Comunicacao.ModelViews.User
{
    public class UserPostRequestBody
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Roles Roles { get; set; }
        public ICollection<Domain.Models.Post?> Posts { get; }
    }
}
