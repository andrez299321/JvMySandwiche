using System;
using System.Collections.Generic;
using System.Text;

namespace EntitysServices.Dto
{
    public class Payment : DTOBase
    {
        public string state { get; set; }
        public int idclient { get; set; }
        public string transactionId { get; set; }
        public string transactionTime { get; set; }
        public string observation { get; set; }
    }
}
