using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_WEBAPIs.DTOs.User
{
    public class UserUpdateRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
    }
}
