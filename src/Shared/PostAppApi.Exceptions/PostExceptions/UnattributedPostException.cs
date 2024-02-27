using PostAppApi.Exceptions.Messages;

namespace PostAppApi.Exceptions.PostExceptions
{
    public class UnattributedPostException : Exception
    {
        public UnattributedPostException() : base(PostMessagesExceptions.UNATTRIBUTED_POST_EXCEPTION) { }
        public UnattributedPostException(string message) : base(message) { }
    }
}
