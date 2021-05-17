using System;
using System.Collections.Generic;
using System.Text;

namespace EntitysServices
{
    public class ClientRequest 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        
        public string Identification { get; set; }
        public string Celphone { get; set; }
        public string Password { get; set; }
    }
}
