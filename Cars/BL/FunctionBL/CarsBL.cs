using BL.ClassesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL.FunctionBL
{
    public class CarsBL
    {
        DBConnection conn = new DBConnection();



        //פונקציית הצגה:
        public List<CarsDTO> GetAllCars()
        {
            DBConnection dbCon = new DBConnection(); ;
            List<Cars> listOfClients = dbCon.GetDbSet<Cars>().ToList();
            return Convert(listOfClients);
        }
        //פונקציית הוספה:
        public string InsertCar(CarsDTO cars)
        {
            DBConnection dbCon = new DBConnection();
            try
            {
                dbCon.Execute<Cars>(Convert(cars), DBConnection.ExecuteActions.Insert);
                return cars.level.ToString();
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
        //פונקציית עדכון:
        public int UpDateCar(CarsDTO cars)
        {
            DBConnection dbCon = new DBConnection();
            try
            {
                dbCon.Execute<Cars>(Convert(cars), DBConnection.ExecuteActions.Update);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //פונקציית מחיקה:
        public int DeleteCar(CarsDTO cars)
        {
            DBConnection dbCon = new DBConnection();
            try
            {
                dbCon.Execute<Cars>(Convert(cars), DBConnection.ExecuteActions.Delete);
                return 1;
            }
            catch
            {
                return 0;
            }
        }






        public List<CarsDTO> GetCarsBySeats(int numseats)
        {
            return Convert(conn.GetDbSet<Cars>().Where(x => x.numSeats == numseats).ToList());
        }

        public List<CarsDTO> GetCarsByLevel(int level)
        {
            return Convert(conn.GetDbSet<Cars>().Where(x => x.level <= level).ToList());
        }
        public List<CarsDTO> GetCarsByPriceForDay(int price)
        {
            return Convert(conn.GetDbSet<Cars>().Where(x => x.priceForDay <= price).ToList());
        }
        public List<CarsDTO> GetCarsByAllCriterions(int level, int price, int numseats)
        {
            return Convert(conn.GetDbSet<Cars>().Where(x => x.level <= level && x.priceForDay <= price && x.numSeats == numseats).ToList());
        }



        public CarsDTO Convert(Cars car)
        {
            CarsDTO car2 = new CarsDTO();
            car2.code = car.code;
            car2.level = car.level;
            car2.priceForThreeDaysAndMore = car.priceForThreeDaysAndMore;
            car2.priceForDay=car.priceForDay;
            car2.numSeats = car.numSeats;
            return car2;
        }
        public Cars Convert(CarsDTO car2)
        {
            Cars car = new Cars();
            car.code = car2.code;
            car.level = car2.level;
            car.priceForThreeDaysAndMore = car2.priceForThreeDaysAndMore;
            car.priceForDay = car2.priceForDay;
            car.numSeats = car2.numSeats;
            return car;
        }
        public List<CarsDTO> Convert(List<Cars> cars)
        {
            List<CarsDTO> list = new List<CarsDTO>();
            foreach (Cars car in cars)
            {
                list.Add(Convert(car));
            }
            return list;
        }
        public List<Cars> Convert(List<CarsDTO> cars)
        {
            List<Cars> list = new List<Cars>();
            foreach (CarsDTO car in cars)
            {
                list.Add(Convert(car));
            }
            return list;
        }



    }

}
