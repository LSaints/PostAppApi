using PostAppApi.Domain.Enums;

namespace PostAppApi.Comunicacao.ModelViews.User
{
    public class UserLoginRequestBody
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Roles { get; set; } = Roles.User;

        public UserLoginRequestBody(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
            Roles = Roles.User;
        }
    }
}
