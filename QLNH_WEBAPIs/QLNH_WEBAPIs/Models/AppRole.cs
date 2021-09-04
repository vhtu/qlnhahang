using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_WEBAPIs.Models
{
    [Table("AppRoles")]
    // Guid kiểu khóa chính toàn hệ thống
    public class AppRole: IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
