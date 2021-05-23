using System;
using System.Collections.Generic;
using System.Text;

namespace EntitysServices.Dto
{
    public class BillingDetail : DTOBase
    {
        public int IdBilling { get; set; }
        public int IdProduct { get; set; }
        public double Price { get; set; }
    }
}
