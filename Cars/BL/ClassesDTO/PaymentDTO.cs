using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ClassesDTO
{
    public class PaymentDTO
    {
        public int code { get; set; }
        public string creaditCard { get; set; }
        public string validity { get; set; }
        public int cvc { get; set; }
    }
}
