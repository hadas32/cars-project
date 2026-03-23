using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ClassesDTO
{
    public class CarsDTO
    {
        public int code { get; set; }
        public int numSeats { get; set; }
        public int level { get; set; }
        public double priceForDay { get; set; }
        public double priceForThreeDaysAndMore { get; set; }

    }
}
