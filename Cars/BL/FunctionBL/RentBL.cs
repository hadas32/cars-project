using BL.ClassesDTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.FunctionBL
{
    public class RentBL
    {
        DBConnection conn = new DBConnection();


        //פונקציית הצגה:
        public List<RentDTO> GetAllRents()
        {
            DBConnection dbCon = new DBConnection(); ;
            List<Rents> listOfClients = dbCon.GetDbSet<Rents>().ToList();
            return Convert(listOfClients);
        }
        //פונקציית הוספה:
        public string InsertRent(RentDTO rent)
        {
            DBConnection dbCon = new DBConnection();
            try
            {
                dbCon.Execute<Rents>(Convert(rent), DBConnection.ExecuteActions.Insert);
                return rent.startDate.ToString();
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
        //פונקציית עדכון:
        public int UpDateRent(RentDTO rent)
        {
            DBConnection dbCon = new DBConnection();
            try
            {
                dbCon.Execute<Rents>(Convert(rent), DBConnection.ExecuteActions.Update);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //פונקציית מחיקה:
        public int DeleteRent(RentDTO rent)
        {
            DBConnection dbCon = new DBConnection();
            try
            {
                dbCon.Execute<Rents>(Convert(rent), DBConnection.ExecuteActions.Delete);
                return 1;
            }
            catch
            {
                return 0;
            }
        }






        //קבלת ההשכרות מהשבוע האחרון
        public List<RentDTO> GetRentFromThisWeek()
        {
            return Convert(conn.GetDbSet<Rents>().ToList()).Where(c => c.startDate < (DateTime.Now.AddDays(-7))).ToList();
        }
        //קבלת ההשכרות מהחודש האחרון
        public List<RentDTO> GetRentFromLastMounth()
        {
            return Convert(conn.GetDbSet<Rents>().ToList()).Where(c => c.startDate <(DateTime.Now.AddDays(-30))).ToList();
        }
        //קבלת ההשכרות שמתחילות היום
        public List<RentDTO> GetRentThatStartToday()
        {
            return Convert(conn.GetDbSet<Rents>().ToList()).Where(c => c.startDate <=(DateTime.Now)).ToList();

        }
        //קבלת ההשכרות שמתחילות בתאריך מסוים
        public List<RentDTO> GetRentThatStartOnDate(DateTime date)
        {
            return Convert(conn.GetDbSet<Rents>().ToList()).Where(c => c.startDate.Equals(date)).ToList();

        }
        //קבלת הרכבים שחוזרים בתאריך מסוים
        public List<RentDTO> GetRentThatEndOnDate(DateTime date)
        {
            return Convert(conn.GetDbSet<Rents>().ToList()).Where(c => c.endDate.Equals(date)).ToList();

        }
        //קבלת רשימת רכבים פנויים מתאריך מסוים ועד לתאריך שני
        public List<CarsDTO> GetRentThatAvailableFromToo(DateTime start, DateTime end)
        {
            return conn.GetDbSet<Rents>()
                .Where(c => c.startDate >= start && c.endDate <= end)
                .Select(r => new CarsDTO
                {
                    code = r.Cars.code,
                    numSeats = r.Cars.numSeats,
                    level = r.Cars.level,
                    priceForDay = r.Cars.priceForDay,
                    priceForThreeDaysAndMore = r.Cars.priceForThreeDaysAndMore
                }).ToList();

        }
        //קבלת רשימת רכבים ע"פ מטרת השכרה
        public List<CarsDTO> GetCarsByGaol(string goal)
        {
            return conn.GetDbSet<Rents>()
               .Where(c => c.goal.Equals(goal))
               .Select(r => new CarsDTO
               {
                   code = r.Cars.code,
                   numSeats = r.Cars.numSeats,
                   level = r.Cars.level,
                   priceForDay = r.Cars.priceForDay,
                   priceForThreeDaysAndMore = r.Cars.priceForThreeDaysAndMore
               }).ToList();
        }
        //קבלת ההשכרות ללקוח ע"פ מ. זהות
        public List<RentDTO> GetRentByCustomerid(int id)
        {
            return Convert(conn.GetDbSet<Rents>().Where(c=>c.codeCustomer==id).ToList());
        }
        //קבלת ההשכרות לרכב ע"פ קוד רכב
        public List<RentDTO> GetRentById(int id)
        {
            return Convert(conn.GetDbSet<Rents>().Where(c => c.codeCar == id).ToList());
        }
        //קבלת כל ההשכרות ממויינות ע"פ תאריך התחלה

        public List<RentDTO> GetRentOrderBy()
        {
            return Convert(conn.GetDbSet<Rents>().OrderBy(c=>c.startDate).ToList());
        }

        public RentDTO Convert(Rents c2)
        {
            RentDTO c1 = new RentDTO();
           c1.code = c2.code;
            c1.codeCar = c2.codeCar;
            c1.codeCustomer = c2.codeCustomer;  
            c1.endDate = c2.endDate;
            c1.startDate = c2.startDate;
            c1.goal = c2.goal;  
            //c1.Cars= c2.Cars;
            //c1.Customers= c2.Customers;
           

            return c1;
        }
        public Rents Convert(RentDTO c2)
        {

            Rents c1 = new Rents();
            c1.code = c2.code;
            c1.codeCar = c2.codeCar;
            c1.codeCustomer = c2.codeCustomer;
            c1.endDate = c2.endDate;
            c1.startDate = c2.startDate;
            c1.goal = c2.goal;
            c1.Cars = c2.Cars;
            c1.Customers = c2.Customers;
            return c1;
        }
        public List<RentDTO> Convert(List<Rents> c1)
        {
            List<RentDTO> list = new List<RentDTO>();
            foreach (Rents c in c1)
            {
                list.Add(Convert(c));
            }
            return list;
        }
        public List<Rents> Convert(List<RentDTO> cs)
        {
            List<Rents> list = new List<Rents>();
            foreach (RentDTO c in cs)
            {
                list.Add(Convert(c));
            }
            return list;
        }
    }
}
