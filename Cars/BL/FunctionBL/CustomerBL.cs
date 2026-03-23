using BL.ClassesDTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL.FunctionBL
{
    public class CustomerBL
    {
        DBConnection conn = new DBConnection();
        public List<CustomersDTO> GetAllClients()
        {
            DBConnection dbCon = new DBConnection(); ;
            List<Customers> listOfClients = dbCon.GetDbSet<Customers>().ToList();
            return Convert(listOfClients);
        }
        //פונקציית הוספה:
        public string InsertClient(CustomersDTO clients)
        {
            DBConnection dbCon = new DBConnection();
            try
            {
                // 🔍 לוג 1: בדיקה מה מגיע
                System.Diagnostics.Debug.WriteLine("=== InsertClient START ===");
                System.Diagnostics.Debug.WriteLine($"Email: {clients.email}");
                System.Diagnostics.Debug.WriteLine($"FirstName: {clients.firstName}");
                System.Diagnostics.Debug.WriteLine($"password: {clients.password}");

                var customer = Convert(clients);

                // 🔍 לוג 2: בדיקה לפני Execute
                System.Diagnostics.Debug.WriteLine("Before Execute...");

                dbCon.Execute<Customers>(customer, DBConnection.ExecuteActions.Insert);

                // 🔍 לוג 3: בדיקה אחרי Execute
                System.Diagnostics.Debug.WriteLine("After Execute - SUCCESS!");
                System.Diagnostics.Debug.WriteLine("=== InsertClient END ===");

                return clients.firstName;
            }
            catch (Exception ex)
            {
                // נחפור פנימה כדי למצוא את השגיאה האמיתית (מה-SQL)
                Exception realError = ex;
                while (realError.InnerException != null)
                {
                    realError = realError.InnerException;
                }

                System.Diagnostics.Debug.WriteLine("❌ Real Error: " + realError.Message);

                // נחזיר לאנגולר את השגיאה המפורטת
                return "error: " + realError.Message;
            }
        }
        public int UpDateClient(CustomersDTO client)
        {
            DBConnection dbCon = new DBConnection();
            try{
                dbCon.Execute<Customers>(Convert(client), DBConnection.ExecuteActions.Update);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //פונקציית מחיקה:
public int DeleteClient(CustomersDTO client)
        {
            DBConnection dbCon = new DBConnection();
            try
            {
                dbCon.Execute<Customers>(Convert(client), DBConnection.ExecuteActions.Delete);
            return 1;
            }
            catch
            {
                return 0;
            }
        }






        //קבלת רשימת לקוחות ממויינת
        public List<CustomersDTO> GetCustomersOrderByName()
        {
            return Convert(conn.GetDbSet<Customers>().ToList()).OrderBy(c => c.firstName).ToList();
        }
        public CustomersDTO Customerbyid(int id)
        {
            return Convert(conn.GetDbSet<Customers>().Find(x => x.Id == id));
        }
        public List<CustomersDTO> GetThreeV()
        {
            return Convert(conn.GetDbSet<Customers>().OrderBy(c => c.numRents).Take(3).ToList());
        }
        public List<CustomersDTO> GetFromCity(int city)
        {
            return Convert(conn.GetDbSet<Customers>().Where(c => c.codeCity == city).ToList());
        }
        public PaymentDTO GetDeatailsPayments(int id)
        {
            PaymentBL pbl = new PaymentBL();
            CustomersDTO index = Convert(conn.GetDbSet<Customers>().FirstOrDefault(x => x.Id == id));
            return pbl.Convert(conn.GetDbSet<Payments>().FirstOrDefault(z => z.code == index.codePayment));
        }



        // ✅ Customers → CustomersDTO
        public CustomersDTO Convert(Customers c2)
        {
            CustomersDTO c1 = new CustomersDTO();
            c1.Id = c2.Id;
            c1.email = c2.email;
            c1.firstName = c2.firstName;
            c1.lastName = c2.lastName;
            c1.password = c2.password; 
            c1.codeCity = c2.codeCity;
            c1.address = c2.address;
            c1.codePayment = c2.codePayment;
            c1.numRents = c2.numRents;
            return c1;
        }
        // ✅ CustomersDTO → Customers
        // ✅ CustomersDTO → Customers
        // ✅ CustomersDTO → Customers
        public Customers Convert(CustomersDTO c2)
        {
            Customers c1 = new Customers();

            // --- התיקון הקריטי ---
            // רק אם ה-ID גדול מ-0 (כלומר זה עדכון ללקוח קיים), אז נעתיק אותו.
            // אם ה-ID הוא 0 (לקוח חדש), אנחנו *לא* נוגעים בו, וה-SQL ייתן מספר לבד.
            if (c2.Id > 0)
            {
                c1.Id = c2.Id;
            }
            // אם c2.Id הוא 0 - לא עושים כלום, ו-c1.Id נשאר ברירת מחדל שה-EF יתעלם ממנו או יסתדר איתו

            c1.email = c2.email;
            c1.firstName = c2.firstName;
            c1.lastName = c2.lastName;
            c1.password = c2.password;
            c1.address = c2.address;

            c1.codeCity = c2.codeCity;
            c1.codePayment = c2.codePayment;
            c1.numRents = c2.numRents ?? 0;

            return c1;
        }
        public List<CustomersDTO> Convert(List<Customers> c1)
        {
            List<CustomersDTO> list = new List<CustomersDTO>();
            foreach (Customers c in c1)
            {
                list.Add(Convert(c));
            }
            return list;
        }
        public List<Customers> Convert(List<CustomersDTO> cs)
        {
            List<Customers> list = new List<Customers>();
            foreach (CustomersDTO c in cs)
            {
                list.Add(Convert(c));
            }
            return list;
        }



    }
}
