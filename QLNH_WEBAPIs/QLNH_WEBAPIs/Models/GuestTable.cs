using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_WEBAPIs.Models
{
    [Table("GuestTables")]
    public class GuestTable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public virtual Status Status { get; set; } //đang chờ, đang order, mới vào, đã tính tiền, còn trống
        public virtual Location Location { get; set; } //bàn này đang ở vị trí nào
        public virtual Guest Guest { get; set; } //khác đang ngổi tên gì
    }
}
