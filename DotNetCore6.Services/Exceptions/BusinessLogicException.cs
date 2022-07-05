using System;

namespace DotNetCore6.Services.Exceptions
{
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException(string message)
       : base(message)
        {
        }
    }
}
