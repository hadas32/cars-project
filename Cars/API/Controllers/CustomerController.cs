using BL.ClassesDTO;
using BL.FunctionBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        CustomerBL cbl = new CustomerBL();

        [AcceptVerbs("Get", "Post", "Delete", "Put")]
        [Route("getallclients")]
        [HttpGet]
        public List<CustomersDTO> GetAllClients()
        {
            return cbl.GetAllClients();
        }

        [Route("insertclient")]
        [HttpPost]
        public string InsertClient([FromBody] CustomersDTO client)
        {
            return cbl.InsertClient(client);
        }

        [Route("updateclient")]
        [HttpPut]
        public int UpDateClient(CustomersDTO client)
        {
            return cbl.UpDateClient(client);
        }

        [Route("deleteclient/{client}")]
        [HttpDelete]
        public int DeleteClient(CustomersDTO client)
        {
            return cbl.DeleteClient(client);
        }

        [Route("getcustomersorderbyname")]
        [HttpGet]
        public List<CustomersDTO> GetCustomersOrderByName()
        {
            return cbl.GetCustomersOrderByName();
        }

        [Route("getcostomerbyid/{id}")]
        [HttpGet]
        public CustomersDTO GetCostomerByID(int id)
        {
            return cbl.Customerbyid(id);
        }

        [Route("GetThreeV")]
        [HttpGet]
        public List<CustomersDTO> GetThreeV()
        {
            return cbl.GetThreeV();
        }

        [Route("getfromcity/{city}")]
        [HttpGet]
        public List<CustomersDTO> GetFromCity(int city)
        {
            return cbl.GetFromCity(city);
        }

        [Route("getdeatailspayments/{id}")]
        [HttpGet]
        public PaymentDTO GetDeatailsPayments(int id)
        {
            return cbl.GetDeatailsPayments(id);
        }

        [Route("login")]
        [HttpGet]
        public CustomersDTO Login([FromUri] string email, [FromUri] string password)
        {
            // 1. הדפסה ראשונית - מה הגיע מהאנגולר?
            System.Diagnostics.Debug.WriteLine($"=== Login Attempt ===");
            System.Diagnostics.Debug.WriteLine($"Input Email: '{email}'");
            System.Diagnostics.Debug.WriteLine($"Input Password: '{password}'");

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                System.Diagnostics.Debug.WriteLine("❌ Error: Email or Password is empty.");
                return null;
            }

            // שליפת כל הלקוחות
            var allClients = cbl.GetAllClients();

            // 2. החיפוש החכם
            // אנחנו משתמשים ב-Trim() כדי למחוק רווחים מיותרים
            // וב-StringComparison.OrdinalIgnoreCase כדי להתעלם מאותיות גדולות/קטנות באימייל
            var result = allClients.FirstOrDefault(c =>
                c.email != null &&
                c.email.Trim().Equals(email.Trim(), StringComparison.OrdinalIgnoreCase) &&
                c.password != null &&
                c.password.Trim() == password.Trim()
            );

            if (result != null)
            {
                System.Diagnostics.Debug.WriteLine($"✅ Success! Found user: {result.firstName} {result.lastName}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("❌ Failed: No user found with these details.");
                // הדפסת עזר - בוא נראה איזה משתמשים כן קיימים במערכת
                System.Diagnostics.Debug.WriteLine("--- Users currently in DB: ---");
                foreach (var u in allClients)
                {
                    System.Diagnostics.Debug.WriteLine($"DB User: '{u.email}' / '{u.password}'");
                }
                System.Diagnostics.Debug.WriteLine("------------------------------");
            }

            return result;
        }

        // שימי לב: אין כאן שום פונקציה שקשורה ל-Cities!
    }
}