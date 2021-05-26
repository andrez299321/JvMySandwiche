using System;
using System.Collections.Generic;
using System.Text;

namespace EntitysServices
{
    public class ProductRequest 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public string Image { get; set; }
    }
}
