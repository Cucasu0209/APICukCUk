using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    public class Customer: BaseEntity
    {
        public string CustomerId { get; set; }
        public string CustomerCode { get; set; }
        
        //public DateTime? CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        //public string ModifiedBy { get; set; }
        public override string GetCode()
        {
            return CustomerCode;
        }

        public override string GetId()
        {
            return CustomerId;
        }
    }
}
