namespace PostAppApi.Comunicacao.ModelViews.Group
{
    public class GroupPostRequestBody
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsFree { get; set; }
        public int OwnerId { get; set; }
    }
}
