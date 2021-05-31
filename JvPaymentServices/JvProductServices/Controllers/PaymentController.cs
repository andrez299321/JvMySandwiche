using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContractsBusiness;
using EntitysServices;
using EntitysServices.ExternalServices;
using RestSharp;
using Utils;

namespace JvAutenticacionServices.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentBL _payment;
        public PaymentController(IPaymentBL payment)
        {
            _payment = payment;
        }


        [HttpPost]
        [Route("CreatePayment")]
        public IActionResult CreatePayment([FromBody] CaptureAndAuthorize payment)
        {

            return Ok(_payment.CreatePayment(payment));
        }



    }
}
