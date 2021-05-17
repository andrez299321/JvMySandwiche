using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContractsBusiness;
using EntitysServices;

namespace JvAutenticacionServices.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentBL _payment;
        public PaymentController(IPaymentBL payment)
        {
            _payment = payment;
        }

        /// <summary>
        /// Authenticates the specified authentication information.
        /// </summary>
        /// <param name="authInfo">The authentication information.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreatePayment")]
        public IActionResult CreatePayment([FromBody] PaymentRequest payment)
        {
            return Ok(_payment.CreatePayment(payment));
        }
    }
}
