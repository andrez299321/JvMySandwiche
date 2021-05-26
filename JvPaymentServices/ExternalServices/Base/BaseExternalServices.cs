using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExternalServices.Base
{
    public class BaseExternalServices
    {
        private RestRequest _request;

        private readonly string _contentType = "application/json";

        private RestClient _client;

        public bool connect(string url) {

            _client = new RestClient(url);
            _client.Timeout = -1;
            _request = new RestRequest();
            _request.AddHeader("Content-Type", _contentType);
            _request.AddHeader("Accept", _contentType);
            return true;
        }

        public IRestResponse Post(string body) 
        {
            _request.Method = Method.POST;
            _request.AddParameter(_contentType, body, ParameterType.RequestBody);
            IRestResponse response = _client.Execute(_request);
            return response;
        }
    }
}
