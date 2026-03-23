using BL.ClassesDTO;
using BL.FunctionBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{

    [RoutePrefix("api/city")]

    public class CityController: ApiController
    {
        CitiesBL cbl = new CitiesBL();
        [AcceptVerbs("Get", "Post", "Delete", "Put")]

        [Route("getallcities")]

        [HttpGet]

        public List<CitiesDTO> GetAllCities()
        {
            return cbl.GetAllCities();
        }
        [Route("insertcities/{city}")]

        [HttpPost]
        public string InsertCities(CitiesDTO city)
        {
            return cbl.InsertCities(city);
        }
        [Route("updatecities/{city}")]

        [HttpPut]
        public int UpDateCities(CitiesDTO city)
        {
            return cbl.UpDateCities(city);
        }
        [Route("deletecities/{city}")]

        [HttpDelete]
        public int DeleteCities(CitiesDTO city)
        {
            return cbl.DeleteCities(city);
        }






    }
}