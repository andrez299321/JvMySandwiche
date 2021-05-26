using EntitysServices.ExternalServices;
using ExternalServices.Base;
using InfraestructureContracts.ExternalServices;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using EntitysServices.GlobalEntity;
using System.Linq;

namespace ExternalServices
{
    public class PaymentExternalServices : BaseExternalServices, IPaymentExternalServices
    {
        IOptions<List<Connections>> _serviceOptions;
        public PaymentExternalServices(IOptions<List<Connections>> serviceOptions)
        {
            _serviceOptions = serviceOptions;
        }

        public string AuthorizationAndCapture( CaptureAndAuthorizeExternalServices capture)
        {
            var url =_serviceOptions.Value.Where(x => x.Name == "PayU").FirstOrDefault();
            connect(url.Endpoint);
            string jsonString = JsonSerializer.Serialize(capture);
            var result = Post(jsonString);
            return result.Content;
        }
    }
}
