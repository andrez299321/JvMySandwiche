using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContractsBusiness;
using EntitysServices;

namespace JvAutenticacionServices.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientBL _client;
        public ClientController(IClientBL client)
        {
            _client = client;
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser([FromBody] ClientRequest client)
        {
            return Ok(_client.CreateUser(client));
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(_client.DeleteUser(id));
        }

        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser([FromBody] ClientRequest client,int id)
        {
            return Ok(_client.UpdateUser(id, client));
        }

        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser(int id)
        {
            return Ok(_client.GetUser(id));
        }
    }
}
