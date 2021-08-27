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
    public class StatusController : ControllerBase
    {
        private readonly QuanlynhahangContext _context;
        public StatusController(QuanlynhahangContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Status> Get()
        {
            return _context.Statuses.ToList();
        }
    }
}
