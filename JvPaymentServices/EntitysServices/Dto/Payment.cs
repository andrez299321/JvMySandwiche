using System;
using System.Collections.Generic;
using System.Text;

namespace EntitysServices.Dto
{
    public class Payment : DTOBase
    {
        public string Name { get; set; }
        public bool State { get; set; }
    }
}
