using System;
using System.Collections.Generic;
using System.Text;

namespace EntitysServices.Dto
{
    public class Product : DTOBase
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
    }
}
