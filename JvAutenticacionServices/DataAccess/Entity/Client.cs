using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entity
{
    public class Client : DTOBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        
        public string Identification { get; set; }
        public string Celphone { get; set; }
        public string Password { get; set; }
    }
}
