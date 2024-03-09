using PostAppApi.Comunicacao.ModelViews.User;
using PostAppApi.Domain.Commons;

namespace PostAppApi.Comunicacao.ModelViews.Post
{
    public class PostGetRequestBody : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public UserGetRequestBody User { get; set; }
        public int GroupId { get; set; }

    }
}
