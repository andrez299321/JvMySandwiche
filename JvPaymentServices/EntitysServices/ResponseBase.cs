using System;
using System.Collections.Generic;
using System.Text;
using Utils.EnumResourse;

namespace EntitysServices
{
    public class ResponseBase
    {
        public EnumResponse Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
