namespace DotNetCore6.Services.Exceptions
{
    public class AuthorizedException : BusinessLogicException
    {
        public AuthorizedException(string message)
            : base(message)
        {

        }
    }
}
