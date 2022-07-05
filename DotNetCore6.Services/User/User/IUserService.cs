using System.Collections.Generic;
using DotNetCore6.Models.Enums;
using DotNetCore6.Models.HR;
using DotNetCore6.Models.User;
using DotNetCore6.ViewModels;
using DotNetCore6.ViewModels.HR;
using DotNetCore6.ViewModels.User.User;

namespace DotNetCore6.Services.HR
{
    public interface IUserService
    {
        User Add(UserCreateViewModel viewModel);
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        bool IsValidToken(string code);
        void Logout();
        void SetLoggedUserID(int userID);
    }
}
