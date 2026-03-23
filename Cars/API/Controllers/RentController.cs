using BL.ClassesDTO;
using BL.FunctionBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/rent")]
    public class RentController : ApiController
    {
        RentBL cbl = new RentBL();

        [AcceptVerbs("Get", "Post", "Delete", "Put")]
        [Route("getallrents")]

        [HttpGet]

        public List<RentDTO> GetAllRents()
        {
            return cbl.GetAllRents();
        }
        [Route("insertrent/rent")]

        [HttpPost]

        public string InsertRent(RentDTO rent)
        {
            return cbl.InsertRent(rent);
        }
        [Route("updaterent/rent")]

        [HttpPut]

        public int UpDateRent(RentDTO rent)
        {
            return cbl.UpDateRent(rent);
        }
        [Route("deleterent/rent")]

        [HttpDelete]
        public int DeleteRent(RentDTO rent)
        {
            return cbl.DeleteRent(rent);
        }

        [Route("getrentfromthisweek")]

        [HttpGet]
        public List<RentDTO> GetRentFromThisWeek()
        {
            return cbl.GetRentFromThisWeek();

        }
        [Route("getrentfromlastmounth")]

        [HttpGet]

        public List<RentDTO> GetRentFromLastMounth()
        {
            return cbl.GetRentFromLastMounth();

        }
        [Route("getrentthatstarttoday")]

        [HttpGet]

        public List<RentDTO> GetRentThatStartToday()
        {
            return cbl.GetRentThatStartToday();

        }
        [Route("getrentthatstartondate/{date}")]

        [HttpGet]

        public List<RentDTO> GetRentThatStartOnDate(DateTime date)
        {
            return cbl.GetRentThatStartOnDate(date);

        }
        [Route("getrentthatendondate/{date}")]

        [HttpGet]

        public List<RentDTO> GetRentThatEndOnDate(DateTime date)
        {
            return cbl.GetRentThatEndOnDate(date);

        }
        [Route("getrentthatavailablefromtoo/{start}/{end}")]

        [HttpGet]

        public List<CarsDTO> GetRentThatAvailableFromToo(DateTime start, DateTime end)
        {
            return cbl.GetRentThatAvailableFromToo(start,end);

        }
        [Route("getcarsbygaol/{goal}")]

        [HttpGet]

        public List<CarsDTO> GetCarsByGaol(string goal)
        {
            return cbl.GetCarsByGaol(goal);

        }
        [Route("getrentbycustomerid/{id}")]

        [HttpGet]

        public List<RentDTO> GetRentByCustomerid(int id)
        {
            return cbl.GetRentByCustomerid(id);

        }
        [Route("getrentbyid/id")]

        [HttpGet]

        public List<RentDTO> GetRentById(int id)
        {
            return cbl.GetRentById(id);

        }
        [Route("getrentorderby")]

        [HttpGet]

        public List<RentDTO> GetRentOrderBy()
        {
            return cbl.GetRentOrderBy();
        }


    }

}
        