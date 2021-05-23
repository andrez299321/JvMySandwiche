using ContractsBusiness;
using EntitysServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JvAutenticacionServices.Controllers
{
    public class LoginController : Controller
    {
        private readonly IClientBL _client;
        public LoginController(IClientBL client)
        {
            _client = client;
        }


        [HttpPost]
        [Route("LoginUser")]
        public IActionResult CreateUser([FromBody] LoginRequest login)
        {
            return Ok(_client.GetLogin(login));
        }
    }
}
