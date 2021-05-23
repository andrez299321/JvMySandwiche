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

        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult CreateProduct([FromBody] ProductRequest product)
        {
            return Ok(_product.CreateProduct(product));
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            return Ok(_product.DeleteProduct(id));
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody] ProductRequest product, int id)
        {
            return Ok(_product.UpdateProduct(id,product));
        }

        [HttpGet]
        [Route("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            return Ok(_product.GetProduct(id));
        }

        [HttpGet]
        [Route("GetAllProduct")]
        public IActionResult GetAllProduct()
        {
            return Ok(_product.GetAllProduct());
        }
    }
}
