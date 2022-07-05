using DotNetCore6.Data.UnitofWork;
using System.Collections.Generic;
using System.Linq;

using DotNetCore6.Models.HR;
using DotNetCore6.ViewModels;
using AutoMapper;
using DotNetCore6.ViewModels.HR;
using AutoMapper.QueryableExtensions;
using DotNetCore6.Data.Extentions;
using DotNetCore6.Models.Enums;
using DotNetCore6.Services.Helpers;
using DotNetCore6.Data.Repository;
using DotNetCore6.Models.User;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using DotNetCore6.ViewModels.User.User;
using DotNetCore6.Helpers;
using Microsoft.Extensions.Options;
using EFCore.BulkExtensions;

namespace DotNetCore6.Services.HR
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Token> _tokenRepository;

        private readonly IMapper _mapper;
        private readonly JWTSettings _jwtSettings;

        public UserService(
            IOptions<JWTSettings> jwtSettings,
            IMapper mapper,
            IRepository<User> userRepository,
            IRepository<Token> tokenRepository,
            IUnitOfWork unitOfWork) : base()
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
            _unitOfWork = unitOfWork;
            _jwtSettings = jwtSettings.Value;

        }





        public string GetUserPasswordSalt(string userName)
        {
            return _userRepository.Get().Where(user => (user.UserName == userName) && !user.IsDeleted).FirstOrDefault()?.SaltPassword ?? null;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest viewModel)
        {
            viewModel.UserName = SecurityHelper.Encrypt(viewModel.UserName.ToLower().Trim());
            string salt = GetUserPasswordSalt(viewModel.UserName);
            if (string.IsNullOrEmpty(salt))
                return null;

            viewModel.Password = SecurityHelper.GetHashedPassword(viewModel.Password, salt);
            int? userID = _userRepository.Get(user => user.UserName == viewModel.UserName && user.Password == viewModel.Password && user.SaltPassword == salt && !user.IsDeleted).FirstOrDefault()?.ID;
            if (userID == null)
                return null;
            var token = generateJwtToken(userID.GetValueOrDefault());
            var encreptedToken = SecurityHelper.Encrypt(token);
            Token userToken = new Token() { UserID = userID.GetValueOrDefault(), Active = true, IP = HttpRequestHelper.GetIP(), Code = encreptedToken, ExpirationDate = DateTime.Now.AddDays(100), UserAgent = HttpRequestHelper.GetUserAgent() };
            _tokenRepository.Add(userToken);
            return new AuthenticateResponse(encreptedToken);
        }

        public User Add(UserCreateViewModel viewModel)
        {
            var model = _mapper.Map<User>(viewModel);
            model.SaltPassword = SecurityHelper.GenerateSalt();
            model.Password = SecurityHelper.GetHashedPassword(model.Password, model.SaltPassword);
            model.UserName = SecurityHelper.Encrypt(viewModel.UserName.ToLower().Trim());
            return _userRepository.Add(model); ;
        }

        public bool IsValidToken(string code)
        {
            DateTime dateTime = DateTime.Now;
            return _tokenRepository.Any(x => x.Code == code && x.Active && x.ExpirationDate > dateTime && x.LoggedOutDate == null);
        }
        public void Logout() {
            _tokenRepository.Get(x=>x.UserID==_unitOfWork.UserID)
                .BatchUpdate(new Token() { LoggedOutDate = DateTime.Now });
        }
        public void SetLoggedUserID(int userID)
        {
            _unitOfWork.UserID = userID;
        }

        // helper methods

        private string generateJwtToken(int userID)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userID.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
