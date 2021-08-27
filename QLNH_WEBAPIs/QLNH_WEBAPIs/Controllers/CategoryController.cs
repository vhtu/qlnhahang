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
    public class CategoryController : Controller
    {
        private readonly QuanlynhahangContext _context;
        public CategoryController(QuanlynhahangContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get all Categories
        /// </summary> 
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _context.Categories.ToList();
        }

        [HttpGet("Id")]
        public Object Get([FromQuery] int Id)
        {
            return _context.Categories.Where(category => category.Id == Id).Select(s => new
            {
                Id = s.Id,
                Name = s.Name,
                Des = s.Description
            }).FirstOrDefault();
        }



    }
}
