using Microsoft.AspNetCore.Mvc;
using QLNH_WEBAPIs.Data;
using QLNH_WEBAPIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_WEBAPIs.Controllers
{
    /// <summary>
    /// API liên quan đến GuestTable
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class GuestTableController : ControllerBase
    {
        private readonly QuanlynhahangContext _context;
        public GuestTableController(QuanlynhahangContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<GuestTable> Get()
        {
            return _context.GuestTables.ToList();
        }
    }
}
