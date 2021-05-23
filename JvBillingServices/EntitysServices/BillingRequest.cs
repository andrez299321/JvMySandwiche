using System;
using System.Collections.Generic;
using System.Text;
using Utils.EnumResourse;

namespace EntitysServices
{
    public class BillingRequest 
    {
        public int Id { get; set; }
        public int Idclient { get; set; }
        public int IdPayment { get; set; }
        public EnumStateBilling State { get; set; }
        public EnumTypeToPayment TypeToPayment { get; set; }
        public EnumTypeToDelivery TypeToDelivery { get; set; }
        public List<BillingProductRequest> products { get; set; }

    }
}
