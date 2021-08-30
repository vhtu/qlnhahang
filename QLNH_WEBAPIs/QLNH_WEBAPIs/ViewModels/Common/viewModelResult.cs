using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_WEBAPIs.ViewModels.Common
{
    public class viewModelResult<T>
    {
        public int TotalRecords { get; set; }
        public List<T> Items { set; get; }
    }
}
