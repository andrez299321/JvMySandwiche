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

        /// <summary>
        /// Authenticates the specified authentication information.
        /// </summary>
        /// <param name="authInfo">The authentication information.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser([FromBody] ClientRequest client)
        {
            //test branch
            //test dos
            return Ok(_client.CreateUser(client));
        }
    }
}
