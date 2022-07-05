namespace DotNetCore6.Services.Exceptions
{
    public class AuthenticatedException : BusinessLogicException
    {
        public AuthenticatedException(string message)
            : base(message)
        {

        }
    }
}
