using System;
using System.Collections.Generic;
using System.Text;

namespace EntitysServices
{
    public class SalesOrderRequest 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
    }
}
