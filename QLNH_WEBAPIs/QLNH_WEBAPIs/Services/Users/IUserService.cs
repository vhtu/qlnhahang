using QLNH_WEBAPIs.DTOs.User;
using QLNH_WEBAPIs.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_WEBAPIs.Services.Users
{
    public interface IUserService
    {
        Task<int> Create(UserCreateRequest request);
        Task<int> Update(UsertUpdateRequest request);
        Task<int> Delete(int userId);
        Task<List<UserViewModel>> GetAll();
        Task<UserViewModel> GetById(int userId);
    }
}
