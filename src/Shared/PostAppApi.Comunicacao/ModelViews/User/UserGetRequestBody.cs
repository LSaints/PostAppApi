using PostAppApi.Comunicacao.ModelViews.Common;

namespace PostAppApi.Comunicacao.ModelViews.User
{
    public class UserGetRequestBody : BaseGetEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
