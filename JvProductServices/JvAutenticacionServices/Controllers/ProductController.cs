using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContractsBusiness;
using EntitysServices;

namespace JvAutenticacionServices.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductBL _product;
        public ProductController(IProductBL product)
        {
            _product = product;
        }

        /// <summary>
        /// Authenticates the specified authentication information.
        /// </summary>
        /// <param name="authInfo">The authentication information.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateProduct([FromBody] ProductRequest product)
        {
            return Ok(_product.CreateProduct(product));
        }
    }
}
