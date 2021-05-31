using System;
using System.Collections.Generic;
using System.Text;

namespace EntitysServices
{
    public class SalesOrderDetailRequest
    {
        public int Idproduct { get; set; }
        public int items { get; set; }
    }

    public class SalesOrderRequest 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public SalesOrderDetailRequest Detail { get; set; }
    }
}
