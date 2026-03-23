using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL.ClassesDTO
{
    public class RentDTO
    {
        public int code { get; set; }
        public int codeCustomer { get; set; }
        public int codeCar { get; set; }
        public System.DateTime startDate { get; set; }
        public System.DateTime endDate { get; set; }
        public string goal { get; set; }
        public virtual Cars Cars { get; set; }
        public virtual Customers Customers { get; set; }
    }
}
