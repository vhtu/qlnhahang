using Microsoft.AspNetCore.Http;
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
    public class ItemController : Controller
    {
        private readonly QuanlynhahangContext _context;
        public ItemController(QuanlynhahangContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all item
        /// </summary> 
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _context.Items.ToList();
        }

        /// <summary>
        /// Deletes a specific Item.
        /// </summary>
        /// <param name="id"></param>        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var item = _context.Items.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Thêm Item mới
        /// </summary>
        /// <returns>Danh sách Item</returns>
        [HttpPost]
        public Item Post([FromQuery] Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return item;
        }

        /// <summary>
        /// Cập nhật item
        /// </summary>
        /// <returns>Danh sách Item</returns>
        [HttpPut]
        public Item Put([FromQuery] Item item)
        {
            var _item = _context.Items.Find(item.Id);
            if (_item == null)
            {
                return null;
            }
            if(item.Name != null)
            {
                _item.Name = item.Name;
            }
            if(item.Description != null)
            {
                _item.Description = item.Description;
            }
            
            
            _context.SaveChanges();
            return _item;
        }
    }
}
