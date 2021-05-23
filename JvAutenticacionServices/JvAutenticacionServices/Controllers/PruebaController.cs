using EntitysServices;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JvAutenticacionServices.Controllers
{
    public class PruebaController : Controller
    {

        
        [HttpPost]
        [Route("methodo")]
        public IActionResult methodo([FromBody] LoginRequest login)
        {
            //https://documenter.getpostman.com/view/1825613/S1TZxb5k#7e242098-00f9-4533-b055-c66c57f11b59
            //http://developers.payulatam.com/plugins/buenas-practicas-y-validaciones-para-API.pdf
            var client = new RestClient("https://sandbox.api.payulatam.com/payments-api/4.0/service.cgi");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", "{\n\t\"test\": true,\n\t\"language\": \"es\",\n\t\"command\": \"CREATE_TOKEN\",\n\t\"merchant\": {\n\t\t\"apiKey\": \"4Vj8eK4rloUd272L48hsrarnUA\",\n\t\t\"apiLogin\": \"pRRXKOl8ikMmt9u\"\n\t},\n\t\"creditCardToken\": {\n\t\t\"payerId\": \"PAYER_ID\",\n\t\t\"name\": \"REJECTED\",\n\t\t\"identificationNumber\": 1000000000,\n\t\t\"paymentMethod\": \"VISA\",\n\t\t\"number\": \"4097440000000004\",\n\t\t\"expirationDate\": \"2022/12\"\n\t}\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return Ok(null);
        }
    }
}
