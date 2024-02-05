using PostAppApi.Comunicacao.ModelViews.Common;
using System.ComponentModel.DataAnnotations;

namespace PostAppApi.Comunicacao.ModelViews.User
{
    public class UserPutRequestBody : BasePutEntity
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
