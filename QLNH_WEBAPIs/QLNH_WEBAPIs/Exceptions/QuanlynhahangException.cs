using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_WEBAPIs.Exceptions
{
    public class QuanlynhahangException : Exception
    {
        public QuanlynhahangException()
        {
        }

        public QuanlynhahangException(string message)
            : base(message)
        {
        }

        public QuanlynhahangException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
