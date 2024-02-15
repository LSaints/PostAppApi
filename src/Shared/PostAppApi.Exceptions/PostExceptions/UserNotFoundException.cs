using PostAppApi.Exceptions.Messages;

namespace PostAppApi.Exceptions.PostExceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base(PostMessagesExceptions.USER_NOT_FOUND_EXCEPTION) { }

        public UserNotFoundException(string message) : base(message) { }
    }
}
