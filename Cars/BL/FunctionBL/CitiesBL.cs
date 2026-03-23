using BL.ClassesDTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.FunctionBL
{
    public class CitiesBL
    {


        DBConnection conn = new DBConnection();

        //פונקציית הצגה:
        public List<CitiesDTO> GetAllCities()
        {
            DBConnection dbCon = new DBConnection(); ;
            List<Cities> listOfCities = dbCon.GetDbSet<Cities>().ToList();
            return Convert(listOfCities);
        }
        //פונקציית הוספה:
        public string InsertCities(CitiesDTO cities)
        {
            DBConnection dbCon = new DBConnection();
            try
            {
                dbCon.Execute<Cities>(Convert(cities), DBConnection.ExecuteActions.Insert);
                return cities.name;
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
        //פונקציית עדכון:
        public int UpDateCities(CitiesDTO cities)
        {
            DBConnection dbCon = new DBConnection();
            try
            {
                dbCon.Execute<Cities>(Convert(cities), DBConnection.ExecuteActions.Update);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //פונקציית מחיקה:
        public int DeleteCities(CitiesDTO cities)
        {
            DBConnection dbCon = new DBConnection();
            try
            {
                dbCon.Execute<Cities>(Convert(cities), DBConnection.ExecuteActions.Delete);
                return 1;
            }
            catch
            {
                return 0;
            }
        }


        public CitiesDTO Convert(Cities car)
        {
            CitiesDTO car2 = new CitiesDTO();
            car2.code = car.code;
           car2.name = car.name;
            return car2;
        }
        public Cities Convert(CitiesDTO car2)
        {
            Cities car = new Cities();
            car.code = car2.code;
            car.name = car2.name;
            return car;
        }
        public List<CitiesDTO> Convert(List<Cities> cars)
        {
            List<CitiesDTO> list = new List<CitiesDTO>();
            foreach (Cities car in cars)
            {
                list.Add(Convert(car));
            }
            return list;
        }
        public List<Cities> Convert(List<CitiesDTO> cars)
        {
            List<Cities> list = new List<Cities>();
            foreach (CitiesDTO car in cars)
            {
                list.Add(Convert(car));
            }
            return list;
        }
    }
}
