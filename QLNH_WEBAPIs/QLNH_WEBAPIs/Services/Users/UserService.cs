using QLNH_WEBAPIs.Data;
using QLNH_WEBAPIs.DTOs.User;
using QLNH_WEBAPIs.Models;
using QLNH_WEBAPIs.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            var user = new User()
            {
                UserName = request.UserName,
                Password = request.Password,
                Description = request.Description
            };
            _context.Users.Add(user);
            return await _context.SaveChangesAsync();
        }

        public Task<int> Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var query = from u in _context.Users select new { u } ;

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
                return _ = new UserViewModel()
                {
                    Id = 0,
                    UserName = null,
                    Description = null
                };
            }
                
            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                UserName = user.Password,
                Description = user.Description
            };
            return userViewModel;
        }

        public Task<int> Update(UsertUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        
    }
}
