﻿using System;
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
        public int IdOrder { get; set; }
        public List<BillingProductRequest> products { get; set; }

    }
}
