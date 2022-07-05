using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore6.ViewModels.User.User
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateViewModel, Models.User.User>().ReverseMap();
        }
    }
}
