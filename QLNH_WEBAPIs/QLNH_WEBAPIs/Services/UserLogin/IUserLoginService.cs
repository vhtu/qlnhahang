using QLNH_WEBAPIs.DTOs.UsersLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_WEBAPIs.Services.UserLogin
{
    public interface IUserLoginService
    {
        Task<string> Autenticate(UserLoginRequest request);
        Task<bool> Register(UserRegisterRequest request);
    }
}
