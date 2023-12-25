using PostAppApi.Application.ModelViews.Common;

namespace PostAppApi.Application.ModelViews.Post
{
    public class PostPutRequestBody : BasePutEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }
}
