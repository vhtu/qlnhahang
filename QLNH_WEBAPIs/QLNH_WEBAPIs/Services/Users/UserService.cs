using QLNH_WEBAPIs.Data;
using QLNH_WEBAPIs.DTOs.User;
using QLNH_WEBAPIs.Models;
using QLNH_WEBAPIs.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QLNH_WEBAPIs.Exceptions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QLNH_WEBAPIs.Services.Users
{
    public class UserService : IUserService
    {
        private readonly QuanlynhahangContext _context;
        public UserService(QuanlynhahangContext context)
        {
            _context = context;
        }
        public async Task<int> Create(UserCreateRequest request)
        {
            var user = new User() //từ Request chuyển sang Entity(model) user ==> thực hiện save
            {
                UserName = request.UserName,
                Password = request.Password,
                Description = request.Description
            };
            _context.Users.Add(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) throw new QuanlynhahangException($"Cannot find a user with id: {userId}");
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<UserRoleViewModel> GeRole(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if(user != null){
                var e = _context.Entry(user);
                e.Reference(u => u.Role).Load();
                //e.Collection(u => u.Role).Load();
            }

            if (user == null) throw new QuanlynhahangException($"Cannot find a user with id: {userId}");
            //var role = await _context.Roles.Where(x => x.Id == user.Role.Id).FirstOrDefaultAsync();
            //if(role == null) throw new QuanlynhahangException($"Cannot find a user with id: {userId}");
            /*
            var roleName = from u in _context.Users
                        join r in _context.Roles on u.Role.Id equals r.Id
                        where u.Id == userId
                        select r.Name;
            */
            var data = new UserRoleViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                RoleName = user.Role.Name
            };

            return data;
        }

        private object Entry(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var query = from u in _context.Users select new { u } ;
            //lấy ra thông tin của user và trả về theo định dạng mà chúng ta muốn
            var data = await query.Select(x => new UserViewModel()
            {
                Id = x.u.Id,
                UserName = x.u.Description,
                Password = x.u.Password
            }).ToListAsync();
            return data;

        }

        public async Task<UserViewModel> GetById(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new QuanlynhahangException($"Cannot find a user with id: {userId}");
            }
            //lấy ra thông tin user có userID và trả về theo đúng thông tin mà chúng ta muốn theo UserViewModel
            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                Description = user.Description
            };
            return userViewModel;
        }



        public async Task<int> Update(UserUpdateRequest request)
        {
            var user = await _context.Users.FindAsync(request.Id);
            if (user == null) throw new QuanlynhahangException($"Cannot find a user with id: {request.Id}");
            user.UserName = request.UserName;
            user.Password = request.Password;
            user.Description = request.Description;
            _context.Users.Update(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> updateDescription(int userID, string newDescription)
        {
            var user = await _context.Users.FindAsync(userID);
            if (user == null) throw new QuanlynhahangException($"Cannot find a user with id: {userID}");
            user.Description = newDescription;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> updatePassword(int userID, string newPassword)
        {
            var user = await _context.Users.FindAsync(userID);
            if (user == null) throw new QuanlynhahangException($"Cannot find a user with id: {userID}");
            user.Password = newPassword;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> updateUserName(int userID, string newUserName)
        {
            var user = await _context.Users.FindAsync(userID);
            if (user == null) throw new QuanlynhahangException($"Cannot find a user with id: {userID}");
            user.UserName = newUserName;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
