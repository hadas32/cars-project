using BL.ClassesDTO;
using BL.FunctionBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/car")]

    public class CarController:ApiController
    {
        CarsBL cbl = new CarsBL();

        [AcceptVerbs("Get", "Post", "Delete", "Put")]//כותרת לכולם באיזה פונ השתמשנו
        [Route("getallcars")]
        [HttpGet]

        public List<CarsDTO> GetAllCars()
        {

            return cbl.GetAllCars();
        }
        [Route("insertcar/{car}")]

        [HttpPost]

        public string InsertCar(CarsDTO car)
        {
            return cbl.InsertCar(car);
        }
        [Route("updatecar/{car}")]

        [HttpPut]
        public int UpDateCar(CarsDTO car)
        {
            return cbl.UpDateCar(car);
        }
        [Route("deletecar/{car}")]

        [HttpDelete]

        public int DeleteCar(CarsDTO car)
        {
            return cbl.DeleteCar(car);
        }
        [Route("getcarsbyseats/{numseats}")]

        [HttpGet]

        public List<CarsDTO> GetCarsBySeats(int numseats)
        {
            return cbl.GetCarsBySeats(numseats);
        }
        [Route("getcarsbylevel/{level}")]

        [HttpGet]
        public List<CarsDTO> GetCarsByLevel(int level)
        {
            return cbl.GetCarsByLevel(level);
        }
        [Route("getcarsbypriceforday/{price}")]

        [HttpGet]
        public List<CarsDTO> GetCarsByPriceForDay(int price)
        {
            return cbl.GetCarsByPriceForDay(price);
        }
        [Route("getcarsbyallcriterions/{level}/{price}/{numseats}")]

        [HttpGet]
        public List<CarsDTO> GetCarsByAllCriterions(int level, int price, int numseats)
        {
            return cbl.GetCarsByAllCriterions(level, price, numseats);
        }
    }
}