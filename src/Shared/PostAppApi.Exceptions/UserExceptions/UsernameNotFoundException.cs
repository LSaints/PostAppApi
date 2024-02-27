using PostAppApi.Exceptions.Messages;

namespace PostAppApi.Exceptions.UserExceptions
{
    public class UsernameNotFoundException : Exception
    {
        public UsernameNotFoundException() : base(UserMessagesExceptions.EMAIL_NOT_FOUND_EXCEPTION) { }
        public UsernameNotFoundException(string message) : base(message) { }
}
}
