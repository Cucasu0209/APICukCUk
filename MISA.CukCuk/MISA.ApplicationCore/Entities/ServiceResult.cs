using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    public class ServiceResult
    {
        public Object data { get; set; }
        public int resultCode { get; set; }
        public string message { get; set; }
    }
}
