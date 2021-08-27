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
    public class LocationController : ControllerBase
    {
        private readonly QuanlynhahangContext _context;
        public LocationController(QuanlynhahangContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return _context.Locations.ToList();
        }
    }
}
