using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContractsBusiness;
using EntitysServices;

namespace JvAutenticacionServices.Controllers
{
    public class BillingController : Controller
    {
        private readonly IBillingBL _billing;
        public BillingController(IBillingBL billing)
        {
            _billing = billing;
        }

        /// <summary>
        /// Authenticates the specified authentication information.
        /// </summary>
        /// <param name="authInfo">The authentication information.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateBilling")]
        public IActionResult CreatesBilling([FromBody] BillingRequest billing)
        {
            return Ok(_billing.CreateBilling(billing));
        }

    }
}
