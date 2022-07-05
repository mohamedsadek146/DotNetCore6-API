using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCore6.ViewModels.User.User
{
    public class AuthenticateResponse
    {
        public string Token { get; set; }

        public AuthenticateResponse(string token)
        {
            Token = token;
        }
    }
}
