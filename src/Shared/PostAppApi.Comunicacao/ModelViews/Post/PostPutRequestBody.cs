using PostAppApi.Comunicacao.ModelViews.Common;

namespace PostAppApi.Comunicacao.ModelViews.Post
{
    public class PostPutRequestBody : BasePutEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }
}
