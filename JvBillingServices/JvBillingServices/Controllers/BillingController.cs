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


        [HttpPost]
        [Route("CreateBilling")]
        public IActionResult CreatesBilling([FromBody] BillingRequest billing)
        {
            return Ok(_billing.CreateBilling(billing));
        }

        [HttpPost]
        [Route("ChangeStateBilling")]
        public IActionResult ChangeStateBilling([FromBody] BillingRequest billing)
        {
            return Ok(_billing.CreateBilling(billing));
        }

        [HttpGet]
        [Route("GetBilling")]
        public IActionResult GetBilling(int id)
        {
            return Ok(_billing.GetBilling(id));
        }

        [HttpGet]
        [Route("GetBillingAll")]
        public IActionResult GetBillingAll()
        {
            return Ok(_billing.GetBillingAll());
        }
    }
}
