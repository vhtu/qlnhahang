using Microsoft.AspNetCore.Mvc;
using QLNH_WEBAPIs.Data;
using QLNH_WEBAPIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_WEBAPIs.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly QuanlynhahangContext _context;
        public RoleController(QuanlynhahangContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lấy tất cả danh sách Roles
        /// </summary>
        /// <returns>Danh sách Roles</returns>
        [HttpGet]  //https://localhost:44364/api/Role
        public IEnumerable<Role> Get()
        {
            return _context.Roles.ToList();
        }

        /// <summary>
        /// Lấy Role với Id - Passing  Parameters Using From RouteAttribute
        /// </summary>
        /// <returns>Danh sách Role</returns>
        /// <param name="Id">Tham số là Id của Role</param>

        //Passing  Parameters Using From RouteAttribute
        // https://localhost:44364/api/Role/2
        [HttpGet("{Id}")]
        //public Role Get([FromQuery] int Id)
        public Role Get(int Id)
        {
            return _context.Roles
                .Where(role => role.Id == Id) //lấy ra role có ID = Id
                .FirstOrDefault(); //Lấy role đầu tiên
        }


        /// <summary>
        /// Lấy Role với Id - Passing  Parameters Using From FromQuery
        /// </summary>
        /// <returns>Danh sách Role</returns>
        /// <param name="Id">Tham số là Id của Role</param>
        //Passing  Parameters Using From FromQuery
        // https://localhost:44364/api/Role/getRole?Id=2
        [HttpGet("getRole")]
        //public Role Get([FromQuery] int Id)
        public Role Get1(int Id)
        {
            return _context.Roles
                .Where(role => role.Id == Id) //lấy ra role có ID = Id
                .FirstOrDefault(); //Lấy role đầu tiên
        }

        //Passing  multi Parameters Using From FromQuery
        // https://localhost:44364/api/Role/getRole1?id=2&name=user1
        /// <summary>
        /// Lấy Role với Id và Name - Passing  Parameters Using From FromQuery
        /// </summary>
        /// <returns>Danh sách Role</returns>
        /// <param name="Id">Tham số là Id của Role</param>
        [HttpGet("getRole1")]
        //public Role Get([FromQuery] int Id)
        public Role Get2(int id, String name)
        {
            return _context.Roles
                .Where(role => role.Id == id && role.Name == name) //lấy ra role có ID = Id
                .FirstOrDefault(); //Lấy role đầu tiên
        }

        /// <summary>
        /// Thêm Role mới
        /// </summary>
        /// <returns>Role</returns>
        [HttpPost]
        public Role Post([FromQuery] Role Role)
        {
            _context.Roles.Add(Role);
            _context.SaveChanges();
            return Role;
        }
    }
}
