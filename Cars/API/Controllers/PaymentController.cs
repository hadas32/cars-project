using BL.FunctionBL;
using BL.ClassesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/payment")]

    public class PaymentController: ApiController
    {
        PaymentBL cbl = new PaymentBL();

        [AcceptVerbs("Get", "Post", "Delete", "Put")]
        [Route("getallpayment")]
        [HttpGet]
        public List<PaymentDTO> GetAllPayment()
        {
            return cbl.GetAllPayment();
        }
        [Route("insertpayment/{payment}")]

        [HttpPost]
        public string InsertPayment(PaymentDTO payment)
        {
           return cbl.InsertPayment(payment);
        }

        [Route("updatepayment/{payment}")]

        [HttpPut]
        public int UpDatePayment(PaymentDTO payment)
        {
            return cbl.UpDatePayment(payment);
        }
        [Route("deletepayment/{payments}")]

        [HttpDelete]
        public int DeletePayment(PaymentDTO payments)
        {
            return cbl.DeletePayment(payments);
        }





    }
}