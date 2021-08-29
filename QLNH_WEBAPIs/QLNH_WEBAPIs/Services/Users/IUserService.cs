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
        Task<int> Update(UserUpdateRequest request);
        Task<int> Delete(int userId);
        Task<List<UserViewModel>> GetAll();
        Task<UserViewModel> GetById(int userId);
        Task<bool> updatePassword(int userID, string newPassword);
        Task<bool> updateUserName(int userID, string newUserName);
        Task<bool> updateDescription(int userID, string newDescription);
        Task<UserRoleViewModel> GeRole(int userId);
    }
}
