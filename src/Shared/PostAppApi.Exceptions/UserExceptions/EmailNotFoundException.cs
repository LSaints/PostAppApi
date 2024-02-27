using PostAppApi.Exceptions.Messages;

namespace PostAppApi.Exceptions.UserExceptions
{
    public class EmailNotFoundException : Exception
    {
        public EmailNotFoundException() : base(UserMessagesExceptions.EMAIL_NOT_FOUND_EXCEPTION) { }
        public EmailNotFoundException(string message) : base(message) { }
    }
}
