using PostAppApi.Exceptions.Messages;

namespace PostAppApi.Exceptions.PostExceptions
{
    [Serializable]
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException() : base(PostMessagesExceptions.NOT_FOUND_EXCEPTION) { }
        public PostNotFoundException(string message) : base(message) { }
    }
}
