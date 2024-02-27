using PostAppApi.Exceptions.Messages;

namespace PostAppApi.Exceptions.UserExceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base(UserMessagesExceptions.NOT_FOUND_EXCEPTION) { }
        public UserNotFoundException(string message) : base(message) { }
    }
}
