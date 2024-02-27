using PostAppApi.Exceptions.Messages;

namespace PostAppApi.Exceptions.PostExceptions
{
    public class UserPostNotFoundException : Exception
    {
        public UserPostNotFoundException() : base(PostMessagesExceptions.USER_NOT_FOUND_EXCEPTION) { }

        public UserPostNotFoundException(string message) : base(message) { }
    }
}
