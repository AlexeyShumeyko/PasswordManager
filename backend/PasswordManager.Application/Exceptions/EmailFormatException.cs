namespace PasswordManager.Application.Exceptions
{
    public class EmailFormatException : Exception
    {
        public EmailFormatException(string message) : base(message)
        {
        }
    }
}
