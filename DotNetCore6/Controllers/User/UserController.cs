using DotNetCore6.API.Filters;
using DotNetCore6.API.Helpers;
using DotNetCore6.Data.UnitofWork;
using DotNetCore6.Helpers;
using DotNetCore6.Localization.Shared;
using DotNetCore6.Services.HR;
using DotNetCore6.ViewModels.Shared;
using DotNetCore6.ViewModels.User.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore6.API.Controllers.User
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ResponseViewModel<string> Login(AuthenticateRequest viewModel)
        {
            var response = _userService.Authenticate(viewModel);
            if (response == null)
                return new ResponseViewModel<string>(null, "invalid user", false);
            _unitOfWork.Save();
            return new ResponseViewModel<string>(response.Token, "", true);
           
        }

        [HttpPost]
        [ValidateViewModel]
        public ResponseViewModel<bool> POST(UserCreateViewModel viewModel)
        {
            _userService.Add(viewModel);
            _unitOfWork.Save();
            return new ResponseViewModel<bool>(true, Resource.SuccessfullyCreated);
        }

        [HttpPost]
        [Authorize]
        public ResponseViewModel<bool> Logout()
        {
            _userService.Logout();
            _unitOfWork.Save();
            return new ResponseViewModel<bool>(true, "logout done");
        }
    }
}
