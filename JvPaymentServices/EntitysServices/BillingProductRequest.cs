using System;
using System.Collections.Generic;
using System.Text;

namespace EntitysServices
{
    public class BillingProductRequest
    {
        public int IdProduct { get; set; }
        public int Items { get; set; }
        public double UnitPrice { get; set; }
    }
}
