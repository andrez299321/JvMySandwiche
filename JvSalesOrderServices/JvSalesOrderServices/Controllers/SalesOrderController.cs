using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContractsBusiness;
using EntitysServices;

namespace JvAutenticacionServices.Controllers
{
    public class SalesOrderController : Controller
    {
        private readonly ISalesOrderBL _salesOrder;
        public SalesOrderController(ISalesOrderBL salesOrder)
        {
            _salesOrder = salesOrder;
        }

        /// <summary>
        /// Authenticates the specified authentication information.
        /// </summary>
        /// <param name="authInfo">The authentication information.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateSalesOrder")]
        public IActionResult CreateSalesOrder([FromBody] SalesOrderRequest salesOrder)
        {
            return Ok(_salesOrder.CreateSalesOrder(salesOrder));
        }


        [HttpGet]
        [Route("GetSalesOrder")]
        public IActionResult GetSalesOrder(int id)
        {
            return Ok(_salesOrder.GetSalesOrder(id));
        }


        [HttpGet]
        [Route("GetAllSalesOrder")]
        public IActionResult GetAllSalesOrder()
        {
            return Ok(_salesOrder.GetAllSalesOrder());
        }

        [HttpDelete]
        [Route("DeleteSalesOrder")]
        public IActionResult DeleteSalesOrder(int id)
        {
            return Ok(_salesOrder.DeleteSalesOrder(id));
        }
    }
}
